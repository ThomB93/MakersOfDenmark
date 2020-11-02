using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeService _badgeService;
        private readonly IMapper _mapper;

        public BadgeController(IBadgeService badgeService, IMapper mapper)
        {
            _badgeService = badgeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<BadgeResource>> CreateBadge(SaveBadgeResource badge)
        {
            var badgeToCreate = _mapper.Map<SaveBadgeResource, Badge>(badge);
            var createdBadge = await _badgeService.CreateBadge(badgeToCreate);
            var badgeToReturn = _mapper.Map<Badge, BadgeResource>(createdBadge);
            return Ok(badgeToReturn);
        }
    }
}