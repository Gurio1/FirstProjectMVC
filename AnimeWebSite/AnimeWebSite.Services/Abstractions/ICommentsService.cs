using AnimeWebSite.Domain.Common;
using AnimeWebSite.Identity.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Services.Abstractions
{
    public interface ICommentsService : IGenericService<AnimeComment>
    {
        Task<bool> CreateAsync(int id, ApplicationUser user, string comment);
    }
}
