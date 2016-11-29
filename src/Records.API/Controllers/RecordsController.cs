using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Records.API.Entities;
using Records.API.Models;
using Records.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Records.API.Controllers
{
    [Route("api")]
    public class RecordsController : Controller
    {
        private ILogger<RecordsController> _logger;
        private IRecordsStoreRepository _recordsStoreRepository;

        public RecordsController(ILogger<RecordsController> logger, IRecordsStoreRepository recordsStoreRepository)
        {
            _logger = logger;
            _recordsStoreRepository = recordsStoreRepository;
        }

        [HttpGet("records")]
        public IActionResult GetRecords(string recordTitle)
        {
            try
            {
                var records = _recordsStoreRepository.GetRecords(recordTitle);

                var recordResult = Mapper.Map<IEnumerable<RecordDto>>(records);

                return Ok(recordResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting the records", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("bands/{bandId}/records")]
        public IActionResult GetBandRecords(int bandId)
        {
            try
            {
                var records = _recordsStoreRepository.GetBandRecords(bandId);

                var recordsResult = Mapper.Map<IEnumerable<RecordDto>>(records);

                return Ok(recordsResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting the band with ID {bandId} records", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("records/{recordId:int}", Name = "GetRecord")]
        public IActionResult GetRecord(int recordId)
        {
            try
            {
                var record = _recordsStoreRepository.GetRecordById(recordId);

                var recordResult = Mapper.Map<RecordDto>(record);

                return Ok(recordResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting the record with ID {recordId}", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("records/{recordTitle}", Name = "GetRecordByTitle")]
        public IActionResult GetRecord(string recordTitle)
        {
            try
            {
                var records = _recordsStoreRepository.GetRecordByTitle(recordTitle);

                var recordsResult = Mapper.Map<IEnumerable<RecordDto>>(records);

                return Ok(recordsResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting the record {recordTitle}", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost("bands/{bandId}/records")]
        public async Task<IActionResult> CreateRecord(int bandId, [FromBody] RecordDto record)
        {
            try
            {
                if (record != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    if (_recordsStoreRepository.GetBandById(bandId) == null)
                    {
                        return NotFound();
                    }

                    if (_recordsStoreRepository.GetRecordByTitle(record.Title).Count() != 0)
                    {
                        return BadRequest($"The record {record.Title} already exists.");
                    }

                    var newRecord = Mapper.Map<Record>(record);

                    _recordsStoreRepository.AddRecord(bandId, newRecord);

                    if (await _recordsStoreRepository.SaveChangesAsync())
                    {
                        var recordToReturn = Mapper.Map<RecordDto>(newRecord);

                        return Created($"/api/bands/{bandId}/records/{recordToReturn.Id}", recordToReturn);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while creating the record", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpPut("records/{recordId}")]
        public async Task<IActionResult> UpdateRecord(int recordId, [FromBody] RecordUpdateDto record)
        {
            try
            {
                if (record != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var recordToUpdate = _recordsStoreRepository.GetRecordById(recordId);

                    if (recordToUpdate == null)
                    {
                        return NotFound();
                    }

                    Mapper.Map(record, recordToUpdate);

                    if (await _recordsStoreRepository.SaveChangesAsync())
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating the record with ID {recordId}", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpPatch("records/{recordId}")]
        public async Task<IActionResult> PatchRecord(int recordId, [FromBody] JsonPatchDocument<RecordUpdateDto> patchDoc)
        {
            try
            {
                if (patchDoc == null)
                {
                    var record = _recordsStoreRepository.GetRecordById(recordId);

                    if (record == null)
                    {
                        return NotFound();
                    }

                    var recordToPatch = Mapper.Map<RecordUpdateDto>(record);

                    patchDoc.ApplyTo(recordToPatch, ModelState);

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    TryValidateModel(recordToPatch);

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    Mapper.Map(recordToPatch, record);

                    if (await _recordsStoreRepository.SaveChangesAsync())
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating the record with ID {recordId}", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpDelete("records/{recordId}")]
        public async Task<IActionResult> DeleteRecord(int recordId)
        {
            try
            {
                var record = _recordsStoreRepository.GetRecordById(recordId);

                if (record == null)
                {
                    return NotFound();
                }

                _recordsStoreRepository.DeleteRecord(record);

                if (await _recordsStoreRepository.SaveChangesAsync())
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while deleting the record with ID {recordId}", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
}
