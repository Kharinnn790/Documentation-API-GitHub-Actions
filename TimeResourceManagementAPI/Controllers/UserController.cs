using Mapster;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TimeResourceManagementAPI.Contracts.User;

namespace TimeResourceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() { return Ok(await _userService.GetAll()); }

        /// <summary>
        /// Получение пользователей по идентификатору (id)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var result = await _userService.GetById(id);
            var response = id.Adapt<User>();
            return Ok(response); 
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "login" : "A4Tech Bloody B188",
        ///        "password" : "!Pa$$word123@",
        ///        "firstname" : "Иван",
        ///        "lastname" : "Иванов",
        ///        "middlename" : "Иванович"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest model)
        {
            var userDto = model.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Изменяет записи пользователей
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest model)
        {
            var userDto = model.Adapt<User>();
            await _userService.Update(userDto);
            return Ok(new { message = "Пользователь успешно обновлен" });
        }

        /// <summary>
        /// Удаляет пользователей по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
