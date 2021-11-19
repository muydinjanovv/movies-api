using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using movies.Entities;

namespace movies.Services
{

public interface IActorService
{
    Task<(bool IsSuccess, Exception Exception, Actor Actor)> CreateAsync(Actor actor);
    Task<List<Actor>> GetAllAsync();
    Task<Actor> GetAsync(Guid id);
    Task<List<Actor>> GetAllAsync(string fullname);
    Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception, Actor Actor)> UpdateAsync(Actor actor);

    // TODO: Upda
}

}