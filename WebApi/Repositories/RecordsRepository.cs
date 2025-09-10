using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.models;
using Newtonsoft.Json;
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
        public async Task<bool> Create(RecordsDTO records)
        {
            try
            {
                var newrecords = new Records();

                var user = apiDatabaseContext.Users.FirstOrDefault(x => x.Id == records.UserId);
                newrecords.User = user;
                string json = JsonConvert.SerializeObject(records.Products);
                newrecords.ProductRecordsJson = json;
                newrecords.MethodOfReceipt = records.MethodOfReceipt;
                newrecords.DateOnly = DateOnly.FromDateTime(DateTime.Now);

                apiDatabaseContext.Records.Add(newrecords);
                apiDatabaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
