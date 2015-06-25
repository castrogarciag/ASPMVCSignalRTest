﻿using ASPMVCProducts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCProducts.Controllers
{
    public class ProductCategoriesController : Controller
    {
        ProductsDb m_tDb = new ProductsDb();
        //
        // GET: /Categories/
				[Authorize]
        public ActionResult Index()
        {
            var lModel = m_tDb.ProductCategories;

            return View(lModel);
        }

        //
        // GET: /Categories/Create
				[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
				[Authorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var lCategory = new ProductCategory()
                {
                    Name = collection["Name"],
                    Description = collection["Description"]
                };
                m_tDb.ProductCategories.Add(lCategory);
                m_tDb.SaveChanges();
            }
            catch (DbUpdateException e)
            {

            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Products/Edit/5
				[Authorize]
        public ActionResult Edit(int id)
        {
            var lCategory = m_tDb.ProductCategories.FirstOrDefault(aCategory => aCategory.Id == id);
            if (lCategory != null)
                return View(lCategory);

            return RedirectToAction("Index");
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
				[Authorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var lCategory = m_tDb.ProductCategories.FirstOrDefault(aCategory => aCategory.Id == id);
                if (lCategory != null)
                {
                    lCategory.Name = collection["Name"];
                    lCategory.Description = collection["Description"];
                    m_tDb.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: /Products/Delete/name=dasdsd
        [HttpPost]
				[Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                var lCategory = m_tDb.ProductCategories.FirstOrDefault(aCategory => aCategory.Id == id);
                if (lCategory != null)
                {
                    m_tDb.ProductCategories.Remove(lCategory);
                    m_tDb.SaveChanges();
                }
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (m_tDb != null)
            {
                m_tDb.Dispose();
                m_tDb = null;
            }
            base.Dispose(disposing);
        }
    }
}
