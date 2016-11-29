using Records.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Records.API.Services
{
    public interface IRecordsStoreRepository
    {
        IEnumerable<Band> GetBands();

        Band GetBandById(int bandId);

        Band GetBandByName(string bandName);

        IEnumerable<Record> GetBandRecords(int bandId);

        IEnumerable<Record> GetRecords(string recordTitle);

        Record GetRecordById(int recordId);

        IEnumerable<Record> GetRecordByTitle(string recordName);

        void AddBand(Band band);

        void AddRecord(int bandId, Record record);

        void DeleteBand(Band band);

        void DeleteRecord(Record record);

        Task<bool> SaveChangesAsync();
    }
}
