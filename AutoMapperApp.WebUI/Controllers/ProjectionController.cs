using AutoMapper;
using AutoMapperApp.WebUI.Dtos;
using AutoMapperApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperApp.WebUI.Controllers
{
    public class ProjectionController : Controller
    {
        private readonly IMapper _mapper;

        public ProjectionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EventDateDto eventDateDto)
        {
            EventDate eventDate = _mapper.Map<EventDate>(eventDateDto);

            ViewBag.EventDate = eventDate;
            return View();
        }
    }
}
