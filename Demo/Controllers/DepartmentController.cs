using AutoMapper;
using Demo.BLL.Interface;
using Demo.BLL.Models;
using Demo.BLL.Repository;
using Demo.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {

        // tightly coupled 
        //DepartmentRep department ; // Field


        // Loosly coupled 
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep _department , IMapper mapper)
        {
            this.department = _department;
            this.mapper = mapper;
        }

        public IActionResult Index(string SearchValue = null)
        {
            if (SearchValue == null || SearchValue == "")
            {
                var data = department.Get();
                var result = mapper.Map <IEnumerable<DepartmentVM>>(data);

                return View(result);

            }
            else
            {
                var data = department.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);

                return View(result);
            }

        }

        public IActionResult Details(int id)
        {

            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Create(data);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                // Handle Exception
                // Log Exception
                return View();
            }

        }

        public IActionResult Edit(int id)
        {

            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Department>(model);
                    department.Edit(data);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                // Handle Exception
                // Log Exception
                return View();
            }

        }

        public IActionResult Delete(int id)
        {

            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var oldData = department.GetById(model.Id);
                department.Delete(oldData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle Exception
                // Log Exception
                return View();
            }

        }

    }
}
