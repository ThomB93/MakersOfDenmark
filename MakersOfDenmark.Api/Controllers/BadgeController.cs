using System;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakersOfDenmark.Api.Controllers

{
    /// <summary>Contains REST endpoints for interacting with the Badge domain.</summary>
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

        /// <summary>This POST method creates a new badge.</summary>
        /// <returns>The badge that was created.</returns>
        [HttpPost]
        public async Task<ActionResult<BadgeResource>> CreateBadge(SaveBadgeResource badge)
        {
            var badgeToCreate = _mapper.Map<SaveBadgeResource, Badge>(badge);
            var createdBadge = await _badgeService.CreateBadge(badgeToCreate);
            var badgeToReturn = _mapper.Map<Badge, BadgeResource>(createdBadge);
            return Ok(badgeToReturn);
        }

        /// <summary>This POST method adds an existing badge to a user.</summary>
        /// <returns>Ok if the badge was added successfully, NotFound otherwise.</returns>
        [HttpPost("{userId}")]
        public async Task<ActionResult<UserBadgeResource>> AddBadgeToUser(Guid userId, [FromBody] BadgeResource badgeToAddResource)
        {
            var badgeToAdd = _mapper.Map<BadgeResource, Badge>(badgeToAddResource);
            try
            {
                var badgeAddedToUser = _badgeService.AddBadgeToUser(userId, badgeToAdd);
                return Ok(badgeAddedToUser);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}