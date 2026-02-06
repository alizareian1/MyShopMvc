using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TachraFac.Datalayer.Entities.User;

namespace TachraFac.Datalayer.Context
{
    public class TachraContext:DbContext
    {
        public TachraContext(DbContextOptions<TachraContext> options):base(options)
        {
            
        }

        #region User
        public DbSet<Role> tblRole { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<UserRole> tblUserRole { get; set; }
        #endregion
    }
}
