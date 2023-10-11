using RedisCrudCommon.Models;

namespace FlavorWorld.Application.Common.Interfaces;

public interface IRedisService<T> where T : EntityBase
{
    bool CreateEntityAsync(T entity, string keyNames);
    bool DeleteEntityAsync(Guid id, string keyNames);
    bool UpdateEntityAsync(T entity, string keyNames);
    List<T> GetAllEntityAsync(string keyNames);
    T GetEntityAsync(Guid id, string keyNames);
}