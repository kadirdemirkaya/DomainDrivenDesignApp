using ElasticSearchCommon.Models;

namespace FlavorWorld.Application.Common.Interfaces;

public interface IElasticsearchService<T> where T : BaseModel
{
    Task<bool> ChekIndex(string indexName);
    Task<bool> CreateIndexAsync();
    Task<bool> InsertAsync(T t);
    Task<T> GetAsync(string id);
    Task<bool> UpdateAsync(T t);
    Task<bool> DeleteByIdAsync(string id);
}