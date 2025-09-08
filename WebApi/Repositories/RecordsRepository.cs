using Microsoft.EntityFrameworkCore;
using Models.models;
using WebApi.Repositories.Interface;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly ApiDatabaseContext apiDatabaseContext;
        public RecordsRepository(ApiDatabaseContext apiDatabaseContext)
        {
            this.apiDatabaseContext = apiDatabaseContext;
        }

        public async Task<bool> Create(Records records)
        {
            if (apiDatabaseContext.Records.Contains(records))
                return false;

            var user = apiDatabaseContext.Users.FirstOrDefault(x => x.Id == records.UserId);
            records.User = user;
            records.ProductRecords = records.ProductRecords;
            apiDatabaseContext.Records.Add(records);
            apiDatabaseContext.SaveChanges();

            return true;
        }
        public async Task<List<Records>> GetRecords()
        {
            return apiDatabaseContext.Records.ToList();
        }
        public async Task<bool> Remote(int userId, int recordId)
        {
            var record = apiDatabaseContext.Records.FirstOrDefault(x => x.UserId == userId && x.Id == recordId);
            if (record == null)
                return false;

            apiDatabaseContext.Records.Remove(record);
            apiDatabaseContext.SaveChanges();

            return true;
        }
        public async Task<List<Records>> GetRecords(int userId)
        {
            return apiDatabaseContext.Records.Include(x => x.User).Where(x => x.UserId == userId).ToList();
        }
    }
}
