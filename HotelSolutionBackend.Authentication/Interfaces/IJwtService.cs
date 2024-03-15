﻿namespace HotelSolutionBackend.Authentication.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Guid id, string name, string email);
    }
}