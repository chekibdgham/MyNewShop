using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LearnjQuery.Models;

namespace LearnjQuery.DAL
{
    public class LearnjQueryInitializer:DropCreateDatabaseIfModelChanges<LearnjQueryContext>
    {
        protected override void Seed(LearnjQueryContext context)
        {
            var connexions = new List<Connexion>
            {
                new Connexion {UserName="chekib",PassWord="chekib123" },
                new Connexion {UserName="ali",PassWord="ali123" },
                new Connexion {UserName="salah",PassWord="salah123" },
                new Connexion {UserName="ahmed",PassWord="ahmed123" },
                new Connexion {UserName="neji",PassWord="neji123" },
                new Connexion {UserName="fahmi",PassWord="fahmi123" },
                new Connexion {UserName="sarra",PassWord="sarra123" },
            };
            connexions.ForEach(p => context.Connexions.Add(p));
            context.SaveChanges();

        }
    }
}