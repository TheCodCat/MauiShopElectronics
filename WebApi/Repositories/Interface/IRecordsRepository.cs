using Models.models;

namespace WebApi.Repositories.Interface
{
    public interface IRecordsRepository
    {
        public Task<bool> Create(Records records);
        public Task<bool> Remote(int userId, int recordId);
        public Task<List<Records>> GetRecords();
        public Task<List<Records>> GetRecords(int userId);
    }
}
