using ElasticSearchCommon.Models;
using ElasticSearchCommon.Repositories;
using FlavorWorld.Application.Common.Interfaces;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class ElasticSearchService<T> : IElasticsearchService<T> where T : BaseModel
{
    private readonly IElasticSearchRepository<T> _elasticSearchRepository;

    public ElasticSearchService(IElasticSearchRepository<T> elasticSearchRepository)
    {
        _elasticSearchRepository = elasticSearchRepository;
    }

    public async Task<bool> ChekIndex(string indexName)
    {
        bool result = await _elasticSearchRepository.ChekIndex(indexName);
        return result;
    }

    public async Task<bool> CreateIndexAsync()
    {
        bool result = await _elasticSearchRepository.CreateIndexAsync();
        return result;
    }

    public async Task<bool> DeleteByIdAsync(string id)
    {
        bool result = await _elasticSearchRepository.DeleteByIdAsync(id);
        return result;
    }

    public async Task<T> GetAsync(string id)
    {
        var data = await _elasticSearchRepository.GetAsync(id);
        return data;
    }

    public async Task<bool> InsertAsync(T t)
    {
        bool result = await _elasticSearchRepository.InsertAsync(t);
        return result;
    }

    public async Task<bool> UpdateAsync(T t)
    {
        bool result = await _elasticSearchRepository.UpdateAsync(t);
        return result;
    }
}