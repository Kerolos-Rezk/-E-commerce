using Demo.BLL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class CountryRep : ICountryRep
    {

        private readonly DemoDbContext db;

        public CountryRep(DemoDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(x => x);

            return data;
        }


        public Country GetById(int id)
        {
            var data = db.Country.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }
    }
}
