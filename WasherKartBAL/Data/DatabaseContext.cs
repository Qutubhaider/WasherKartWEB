using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WasherKartBAL.User.Models;

namespace WasherKartBAL.Data
{
    public class DatabaseContext:IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>Options):base(Options)
        {

        }       
        public DbSet<User.Models.UserEmailResult> UserEmailResult { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserProfileDetails> UserProfileDetails { get; set; }
        public DbSet<UserTranscationLog> UserTranscationLog { get; set; }
        public DbSet<TranscationDetails> TranscationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder foModelbuilder)
        {            
            foModelbuilder.Entity<User.Models.UserEmailResult>().HasNoKey();           
            foModelbuilder.Entity<UserProfile>().HasNoKey();
            foModelbuilder.Entity<UserProfileDetails>().HasNoKey();
            foModelbuilder.Entity<UserTranscationLog>().HasNoKey();
            foModelbuilder.Entity<TranscationDetails>().HasNoKey();
            base.OnModelCreating(foModelbuilder);
        }
    }    
}
