using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppStore.Models.Domain
{
    public class DatabaseContext: IdentityDbContext<ApplicationUser>
    {
        
    }
}