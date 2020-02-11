using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ParkyAPI.Repository.IRepository;
using ParkyAPI.Models.Dtos;

namespace ParkyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepository _repo;
        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNationalParks()
        {
            var parks = await _repo.GetNationalParks();
            if (parks == null)
                return NotFound();

            var parksDto = _mapper.Map<ICollection<NationalParkDto>>(parks);
            return Ok(parksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNationalPark(int id)
        {
            var park = await _repo.GetNationalPark(id);
            if (park == null)
                return NotFound();
            
            var parkToDto = _mapper.Map<NationalParkDto>(park);
            return Ok(parkToDto);
        }
    }
}