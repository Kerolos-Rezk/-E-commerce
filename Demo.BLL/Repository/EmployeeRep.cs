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
    public class EmployeeRep : IEmployeeRep
    {


        private readonly DemoDbContext db;

        public EmployeeRep(DemoDbContext db)
        {
            this.db = db;
        }



        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department")
                                  .Include("District")
                                  .Select(x => x);

            return data;
        }


        public Employee GetById(int id)
        {
            var data = db.Employee.Include("Department").Where(x => x.Id == id).FirstOrDefault();

            return data;
        }

        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department").Where(x => x.Name == Name).Select(x => x);

            return data;
        }


        public void Create(Employee obj)
        {

            db.Employee.Add(obj);
            db.SaveChanges();
        }

        public void Edit(Employee obj)
        {

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }
    }
}
