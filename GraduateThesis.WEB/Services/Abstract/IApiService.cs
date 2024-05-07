namespace GraduateThesis.WEB.Services.Abstract
{
    public interface IApiService<TViewModel>
    {
        Task<List<TViewModel>> GetAllAsync(string endpoint);
        Task<TViewModel> GetByIdAsync(int id, string endpoint);
        Task<TViewModel> SaveAsync(TViewModel newEntity, string endpoint);
        Task<bool> UpdateAsync(TViewModel entity, string endpoint);
        Task<bool> RemoveAsync(int id, string endpoint);
    }
}
