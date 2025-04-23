using Domain.Entity;
using Domain.Enum;
using Domain.Interface;
using LocateMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocateMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMap _map;
        
        public HomeController(ILogger<HomeController> logger, IMap map)
        {
            _logger = logger;
            _map = map;
           
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public IActionResult LocationData(Map map)
        {
            
            var result = _map.Add(map);
            var message = new Message();

            message.Status = result;


            switch (result)
            {
                case Domain.Enum.OpStatus.Success:
                    message.MessageData = "Student added sucessfully";
                    break;
                case Domain.Enum.OpStatus.Error:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
                case Domain.Enum.OpStatus.UserAlreadyExists:
                    message.MessageData = "PhoneNumber is alreay exists";
                    break;
                default:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
            }
            ViewData["UIMessage"] = message;
            var MapList = _map.List();
            ViewData["MapList"] = MapList;
            

            return View("Index");

        }
        [HttpPost]
        public IActionResult UpdateData( Map map)
        {
         
            var result = _map.Update(map);
            var message = new Message();

            message.Status = result;


            switch (result)
            {
                case Domain.Enum.OpStatus.Success:
                    message.MessageData = "Student added sucessfully";
                    break;
                case Domain.Enum.OpStatus.Error:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;              
                default:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
            }
            ViewData["UIMessage"] = message;
            var MapList = _map.List();
            ViewData["MapList"] = MapList;
           

            return View("Index");

        }

        [HttpPost]
        public IActionResult DeleteLocation(Guid Id)
        {
            var result = _map.Delete(Id);
            var message = new Message();

            message.Status = result;


            switch (result)
            {
                case Domain.Enum.OpStatus.Success:
                    message.MessageData = "Student added sucessfully";
                    break;
                case Domain.Enum.OpStatus.Error:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
                case Domain.Enum.OpStatus.UserAlreadyExists:
                    message.MessageData = "PhoneNumber is alreay exists";
                    break;
                default:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
            }
            ViewData["UIMessage"] = message;
            var MapList = _map.List();
            ViewData["MapList"] = MapList;
            

            return View("Index");

        }

        [HttpPost]
        public IActionResult GetById(Guid Id)
        {
            var result = _map.GetById(Id);
            var message = new Message();

            if (result != null) {
                message.Status = OpStatus.Success;
            }else
            {
                message.Status = OpStatus.Error;
            }
           
            switch (message.Status)
            {
                case Domain.Enum.OpStatus.Success:
                    message.MessageData = "Student added sucessfully";
                    break;
                case Domain.Enum.OpStatus.Error:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
                default:
                    message.MessageData = "Sorry we have issues, please try again later :(";
                    break;
            }
            ViewData["UIMessage"] = message;
            var MapList = _map.List();
            ViewData["MapList"] = MapList;
            ViewData["value"] = result;
       

            return View("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
