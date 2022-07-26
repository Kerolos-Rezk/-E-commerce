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
    public class DistrictRep : IDistrictRep
    {
        private readonly DemoDbContext db;

        public DistrictRep(DemoDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<District> Get()
        {
            var data = db.District.Select(x => x);

            return data;
        }


        public District GetById(int id)
        {
            var data = db.District.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }
    }
}
