using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ParkyAPI.Repository.IRepository;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Models;

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

        [HttpGet("{id}", Name = "GetNationalPark")]
        public async Task<IActionResult> GetNationalPark(int id)
        {
            var park = await _repo.GetNationalPark(id);
            if (park == null)
                return NotFound();
            
            var parkToDto = _mapper.Map<NationalParkDto>(park);
            return Ok(parkToDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNationalPark([FromBody] NationalParkDto dto)
        {
            if (dto == null)
                return BadRequest(ModelState);
            
            if (await _repo.NationalParkExists(dto.Name))
            {
                ModelState.AddModelError("", "National Park already exists!");
                return StatusCode(404, ModelState);
            }
            
            var nationalPark = _mapper.Map<NationalPark>(dto);
            if (await _repo.CreateNationalPark(nationalPark)  == false)
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {nationalPark.Name}");
                return StatusCode(500, ModelState);
            }
            
            return CreatedAtRoute("GetNationalPark", new { id = nationalPark.Id}, nationalPark);
        }

        [HttpPatch("{id}", Name = "UpdateNationalPark")]
        public async Task<IActionResult> UpdateNationalPark(int id, [FromBody] NationalParkDto dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest(ModelState);


            var nationalPark = _mapper.Map<NationalPark>(dto);
            if (await _repo.UpdateNationalPark(nationalPark) == false)
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {nationalPark.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteNationalPark")]
        public async Task<IActionResult> DeleteNationalPark(int id)
        {
            if (await _repo.NationalParkExists(id) == false)
                return NotFound();
            
            var nationalPark = await _repo.GetNationalPark(id);
            if (await _repo.DeleteNationalPark(nationalPark) == false)
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {nationalPark.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}