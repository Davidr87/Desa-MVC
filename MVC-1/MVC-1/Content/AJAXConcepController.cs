﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_1.Content
{
    public class AJAXConcepController : Controller
    {
        // GET: AJAXConcep
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult JsonFactorial(int n)
        {
            if (!Request.IsAjaxRequest())
            {
                return null;
            }

            var result = new JsonResult
            {
                Data = new { Factorial = Factorial(n) }
            };

            return result;
        }

            private object Factorial(int n)
            {
                double factorial = 1;
                for (int i = 2; i <= n; i++)
                {
                factorial *= i;
                }
            return factorial;
            }

        

    }
}