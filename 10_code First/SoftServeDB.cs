﻿using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace _10_code_First
{
    public class SoftServeDB : DbContext
    {

        public SoftServeDB()
            : base("name=SoftServeDB")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
 
    }

}