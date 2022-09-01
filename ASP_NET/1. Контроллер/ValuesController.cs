using WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    //
    [Route("api/[controller]")]
    [ApiController]

    //Класс контроллера, наследуем от базового конроллера (без MVC)
    public class ValuesController : ControllerBase
    {
        //GET запрос
        [HttpGet]
        public IActionResult TestController()
        {
            return Ok("Yep");
        }
    }

    
    [Route("/")]
    [ApiController]
    // Ещё один класс, наследуем от контроллера с MVC
    public class MainController : Controller
    {
        /// <summary>
        /// Returns array of UserClass
        /// </summary>
        /// <param name="number">Size of array</param>
        /// <param name="name"> Сommon name </param>
        /// <returns> UserClass Array</returns>
        [HttpGet]
        //Пробуем сгненерировать определённое кол-во юзеров (модель) кол-ва number 
        public UserClass[] GetMainPage([FromQuery]string number, string name)
        {
            var random = new Random();
            var Users = new List<UserClass>();

            var temp = 0;
            int.TryParse(number, out temp);

            //тупо в цикле создаём, инициализируем модельки и добавляем к списку
            for (uint i = 0; i < temp; i++)
            {
                var user = new UserClass();

                user.Name = name;
                user.Id = i;

                user.Birth = DateTime.Now.AddDays(i + random.Next(0, 10000));

                Users.Add(user);
            }
            var response = Users.ToArray();

            //
            return response;
        }

    }
}
