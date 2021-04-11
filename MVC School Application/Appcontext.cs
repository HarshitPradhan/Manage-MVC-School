using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_School_Application
{
    public class Appcontext : DbContext
    {
        public Appcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Models.StudentModel> StudentModel { get; set; }
        public DbSet<Models.ClassModel> ClassModel { get; set; }
        public DbSet<Models.SubjectModel> SubjectModel { get; set; }

    }
}
