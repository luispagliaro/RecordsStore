using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Records.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Records.API.Services
{
    public class RecordsStoreRepository : IRecordsStoreRepository
    {
        private RecordsStoreContext _context;

        public RecordsStoreRepository(RecordsStoreContext context)
        {
            _context = context;
        }

        public Band GetBandById(int bandId)
        {
            return _context.Bands
                .Include(b => b.Records)
                .Where(b => b.Id == bandId)
                .FirstOrDefault();
        }

        public Band GetBandByName(string bandName)
        {
            return _context.Bands
                .Include(b => b.Records)
                .Where(b => b.Name == bandName)
                .FirstOrDefault();
        }

        public IEnumerable<Record> GetBandRecords(int bandId)
        {
            return _context.Records
                .Where(r => r.BandId == bandId)
                .ToList();
        }

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands
                .OrderBy(b => b.Name)
                .ToList();
        }

        public Record GetRecordById(int recordId)
        {
            return _context.Records
                .Where(r => r.Id == recordId)
                .FirstOrDefault();
        }

        public IEnumerable<Record> GetRecordByTitle(string recordTitle)
        {
            return _context.Records
                .Where(r => r.Title == recordTitle)
                .ToList();
        }

        public IEnumerable<Record> GetRecords(string recordTitle)
        {
            if (recordTitle == null)
            {
                return _context.Records.
                    OrderBy(r => r.Title).
                    ToList();
            }
            else
            {
                return _context.Records
                    .Where(r => r.Title.Contains(recordTitle));
            }
            
        }

        public void AddBand(Band band)
        {
            _context.Add(band);
        }

        public void AddRecord(int bandId, Record record)
        {
            var band = GetBandById(bandId);

            band.Records.Add(record);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void DeleteBand(Band band)
        {
            _context.Remove(band);
        }

        public void DeleteRecord(Record record)
        {
            _context.Remove(record);
        }
    }
}
