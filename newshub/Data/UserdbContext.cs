using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using newshub.Controllers;
using newshub.Models;

namespace newshub.Data
{
    public class UserdbContext : DbContext
    {

        public UserdbContext(DbContextOptions<UserdbContext> options)
        : base(options)
        {

        }

       public DbSet<Register> Users { get; set; }
       public DbSet<cardData1> cardData { get; set; }

        public DbSet<Nadmin> Admin { get; set; }

        


    }
}

