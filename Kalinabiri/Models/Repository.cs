using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Kalinabiri.Models
{
    public class Repository:DbContext
    {

        public Repository()
            : base("DefaultConnection")
        { 
        

        }

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<SupportStaff> SupportStaff { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<NextOfKin> NextOfKin { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<SubjectAndTeacher> SubjectAndTeacher { get; set; }
    }
}