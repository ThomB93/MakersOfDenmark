using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core.Models.Makerspaces;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MakerspaceController : ControllerBase
    {
        private readonly IMakerspaceService _makerspaceService;
        private readonly IMapper _mapper;
        
        public MakerspaceController(IMakerspaceService makerspaceService, IMapper mapper)
        {
            this._mapper = mapper;
            this._makerspaceService = makerspaceService;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MakerspaceResource>>> GetAllMakerspacesWithOwners()
        {
            var makerspaces = await _makerspaceService.GetAllMakerspacesWithOwner();
            var makerspaceResources = _mapper.Map<IEnumerable<Makerspace>, IEnumerable<MakerspaceResource>>(makerspaces);

            return Ok(makerspaceResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MakerspaceResource>>> GetMakerspaceWithOwnerById(int id)
        {
            var makerspace = await _makerspaceService.GetMakerspaceWithOwnerById(id);
            var makerspaceResource = _mapper.Map<Makerspace, MakerspaceResource>(makerspace);

            return Ok(makerspaceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<Makerspace>> CreateMakerspace(
            [FromBody] SaveMakerspaceResource saveMakerspaceResource)
        {
            //TODO: Add validation code
            
            var makerspaceToCreate = _mapper.Map<SaveMakerspaceResource, Makerspace>(saveMakerspaceResource);
            var newMakerspace = await _makerspaceService.CreateMakerspace(makerspaceToCreate);
            var makerspace = await _makerspaceService.GetMakerspaceWithOwnerById(newMakerspace.Id);
            var makerspaceResource = _mapper.Map<Makerspace, MakerspaceResource>(makerspace);

            return Ok(makerspaceResource);
        }
        
        //TODO: Make it possible to update owner id
        [HttpPut("{id}")]
        public async Task<ActionResult<Makerspace>> UpdateMakerspace(int id,
            [FromBody] SaveMakerspaceResource saveMakerspaceResource)
        {
            //TODO: Add validation code

            var makerspaceToBeUpdated = await _makerspaceService.GetMakerspaceWithOwnerById(id);

            if (makerspaceToBeUpdated == null)
            {
                return NotFound();
            }
            
            var makerspace = _mapper.Map<SaveMakerspaceResource, Makerspace>(saveMakerspaceResource);

            await _makerspaceService.UpdateMakerspace(makerspaceToBeUpdated, makerspace );

            var updatedMakerspace = await _makerspaceService.GetMakerspaceWithOwnerById(id);
            var updatedMakerspaceResource = _mapper.Map<Makerspace, SaveMakerspaceResource>(updatedMakerspace);
            
            return Ok(updatedMakerspaceResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMakerspace(int id)
        {
            if (id == 0)
                return BadRequest();
            
            var makerspace = await _makerspaceService.GetMakerspaceWithOwnerById(id);

            if (makerspace == null)
                return NotFound();

            await _makerspaceService.DeleteMakerspace(makerspace);

            return NoContent();
        }
    }
}