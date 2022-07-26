using Demo.BLL.Interface;
using Demo.BLL.Models;
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
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DemoDbContext db;

        public DepartmentRep(DemoDbContext db)
        {
            this.db = db;
        }

      

        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(x => x);

            return data;
        }


        public Department GetById(int id)
        {
            var data = db.Department.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }

        public IEnumerable<Department> SearchByName(string Name)
        {
            var data = db.Department.Where( x => x.DepartmentName == Name).Select( x => x );

            return data;
        }


        public void Create(Department obj)
        {

            db.Department.Add(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)
        {

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Department obj)
        {
            db.Department.Remove(obj);
            db.SaveChanges();
        }



   





    }
}
