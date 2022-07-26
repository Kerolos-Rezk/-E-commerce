using Demo.BLL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly DemoDbContext db;

        public CityRep(DemoDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<City> Get()
        {
            var data = db.City.Select(x => x);

            return data;
        }


        public City GetById(int id)
        {
            var data = db.City.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }
    }
}
