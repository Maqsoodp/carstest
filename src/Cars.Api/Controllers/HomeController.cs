﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("cars")]
        public ActionResult Cars()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("owners")]
        public ActionResult Owners()
        {
            return RedirectToAction("Index");
        }

    }
}