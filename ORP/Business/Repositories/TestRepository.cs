using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORP.Model;
using ORP.Models;

namespace ORP
{
    public class TestRepository
    {
        private string connectionString =
            "Data Source=dbs-oapl.database.windows.net;Initial Catalog=db-prod;User ID=dbs-oapl;Password=oceanicFlyAway16";

        public bool AddUser()
        {
            using (var context = new OrpContext())
            {
                context.Users.Add(new User
                {
                    Name = "Mads",
                    Clearance = new Clearance
                    {
                        Level = 1,
                        Name = "CIA"
                    },
                    Password = "password1"
                });
                context.SaveChanges();
            }

            return true;

        }
    }
}