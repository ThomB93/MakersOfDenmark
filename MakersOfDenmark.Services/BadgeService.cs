﻿using System;
using System.Linq;
using System.Threading.Tasks;
using MakersOfDenmark.Core;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Models.Badges;
using MakersOfDenmark.Core.Models.UserRelations;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace MakersOfDenmark.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager;

        public BadgeService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }
        
        public async Task<Badge> CreateBadge(Badge newBadge)
        {
            await _unitOfWork.Badges.AddAsync(newBadge);
            await _unitOfWork.CommitAsync();                    
            
            return newBadge;
        }

        public Badge AddBadgeToUser(Guid userId, Badge badge)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            user?.UserBadges.Add(new UserBadge { Badge = badge, BadgeId = badge.Id, User = user, UserId = user.Id });
            return badge;
        }

    }
}