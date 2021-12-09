using Cleverti.Assessment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cleverti.Assessment.Domain.Interfaces.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> FindAll();
        Task<Todo> FindById(int id);
        Task<Todo> Add(Todo todo);
        Task<Todo> Update(Todo todo);
        Task Remove(int id);
    }
}
