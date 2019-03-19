using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LearnjQuery.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LearnjQuery.DAL
{
    public class LearnjQueryContext:DbContext
    {
        public LearnjQueryContext() : base("LearnjQueryContext")
        {
        }
        public DbSet<Connexion> Connexions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}