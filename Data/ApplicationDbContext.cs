using CourseWorkSpring2023.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSpring2023.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostsTags> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserContentRates> Rates { get; set; }
     //   public DbSet<UsersPostsRates> UsersPostsRates { get; set; }
      //  public DbSet<UsersCommentsRates> UsersCommentsRates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
