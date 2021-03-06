﻿using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}