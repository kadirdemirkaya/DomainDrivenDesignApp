using FlavorWorld.Application.Common.Interfaces;
using RedisCrudCommon.Enums;
using RedisCrudCommon.Models;
using RedisCrudCommon.Repositories;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class RedisService<T> : IRedisService<T> where T : EntityBase
{
    private readonly IRepository<T> _redisRepository;

    public RedisService(IRepository<T> redisRepository)
    {
        _redisRepository = redisRepository;
    }

    public bool CreateEntityAsync(T entity, string keyNames)
    {
        bool result = _redisRepository.Create(keyNames, entity, RedisDataType.Hash);
        return result is true ? true : false;
    }

    public bool DeleteEntityAsync(Guid id, string keyNames)
    {
        bool result = _redisRepository.Delete(keyNames, id.ToString(), RedisDataType.Hash);
        return result is true ? true : false;
    }

    public List<T> GetAllEntityAsync(string keyNames)
    {
        List<T>? ents = _redisRepository.GetAll(keyNames, RedisDataType.Hash)!.ToList()!;
        return ents is not null ? ents : null!;
    }

    public T GetEntityAsync(Guid id, string keyNames)
    {
        T? ent = _redisRepository.GetById(keyNames, id.ToString(), RedisDataType.Hash);
        return ent is not null ? ent : null!;
    }


    public bool UpdateEntityAsync(T entity, string keyNames)
    {
        bool result = _redisRepository.Update(keyNames, entity, RedisDataType.Hash);
        return result is true ? true : false;
    }
}