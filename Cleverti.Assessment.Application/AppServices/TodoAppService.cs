using Cleverti.Assessment.Application.Interfaces;
using Cleverti.Assessment.Domain.Entities;
using Cleverti.Assessment.Domain.Interfaces;
using Cleverti.Assessment.Domain.Interfaces.Cache;
using Cleverti.Assessment.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverti.Assessment.Application.AppServices
{
    public class TodoAppService : ITodoAppService
    {
        private readonly ITodoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoAppService(ITodoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Todo> Add(Todo todo)
        {
            await _repository.Add(todo);
            _unitOfWork.Commit();
            return todo;
        }

        public async Task<IEnumerable<Todo>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Todo> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task Remove(int id)
        {
             await _repository.FindById(id);
            _unitOfWork.Commit();
        }

        public async Task<Todo> Update(Todo todo)
        {
             await _repository.Update(todo);
            _unitOfWork.Commit();
            return todo;
        }
    }
}
