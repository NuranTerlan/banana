using System.Security.Claims;
using Application.Commons.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Presentation_API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}