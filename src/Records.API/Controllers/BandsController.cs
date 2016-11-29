using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Records.API.Entities;
using Records.API.Models;
using Records.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Records.API.Controllers
{
    [Route("api/bands")]
    public class BandsController : Controller
    {
        private ILogger<BandsController> _logger;
        private IRecordsStoreRepository _recordsStoreRepository;

        public BandsController(ILogger<BandsController> logger, IRecordsStoreRepository recordsStoreRepository)
        {
            _logger = logger;
            _recordsStoreRepository = recordsStoreRepository;
        }

        [HttpGet()]
        public IActionResult GetBands()
        {
            try
            {
                var bands = _recordsStoreRepository.GetBands();

                var bandsResult = Mapper.Map<IEnumerable<BandDto>>(bands);

                return Ok(bandsResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting the bands", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{bandName}", Name = "GetBand")]
        public IActionResult GetBand(string bandName)
        {
            try
            {
                var band = _recordsStoreRepository.GetBandByName(bandName);

                if (band == null)
                {
                    return NotFound();
                }

                var bandResult = Mapper.Map<BandDto>(band);

                return Ok(bandResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting the band {bandName}", ex);

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBand([FromBody] BandUpdateDto band)
        {
            try
            {
                if (band != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    if (!_recordsStoreRepository.GetBandByName(band.Name).Equals(null))
                    {
                        return BadRequest($"The band {band.Name} already exists.");
                    }

                    var newBand = Mapper.Map<Band>(band);

                    _recordsStoreRepository.AddBand(newBand);

                    if (await _recordsStoreRepository.SaveChangesAsync())
                    {
                        var newBandToReturn = Mapper.Map<BandDto>(newBand);

                        return CreatedAtRoute("GetBand", new { bandName = newBandToReturn.Name }, newBandToReturn);
                    }
                }                
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while creating the band", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpPut("{bandId}")]
        public async Task<IActionResult> UpdateBand(int bandId, [FromBody] BandDto band)
        {
            try
            {
                if (band != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var bandToUpdate = _recordsStoreRepository.GetBandById(bandId);

                    if (bandToUpdate == null)
                    {
                        return NotFound();
                    }

                    Mapper.Map(band, bandToUpdate);

                    if (await _recordsStoreRepository.SaveChangesAsync())
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while updating the band with ID {bandId}", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpDelete("{bandId}")]
        public async Task<IActionResult> DeleteBand(int bandId)
        {
            try
            {
                var band = _recordsStoreRepository.GetBandById(bandId);

                if (band == null)
                {
                    return NotFound();
                }

                _recordsStoreRepository.DeleteBand(band);

                if (await _recordsStoreRepository.SaveChangesAsync())
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while deleting the band with ID {bandId}", ex);
            }

            return StatusCode(500, "A problem happened while handling your request.");
        }
    }
}
