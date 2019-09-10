using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Core.Interfaces;
using ToDo.Data.Entities;
using ToDo.Repositories.Interfaces;

namespace ToDo.Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository todoRepository, IMapper mapper,
            IUserRepository userRepository)
        {
            _todoRepository = todoRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TodoDTO> CreateTodo(TodoDTO todo)
        {
            var mappedTodo = _mapper.Map<Todo>(todo);
            var createdTodo = await _todoRepository.CreateTodo(mappedTodo);
            return _mapper.Map<TodoDTO>(createdTodo);
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _todoRepository.GetTodo(id);
            await _todoRepository.DeleteTodo(todo);
        }

        public async Task<IEnumerable<TodoDTO>> GetUserTodos(string username)
        {
            var userId = await _userRepository.GetUserId(username);

            var todos = await _todoRepository.GetUserTodos(userId);
            return _mapper.Map<IEnumerable<TodoDTO>>(todos);
        }
    }
}
