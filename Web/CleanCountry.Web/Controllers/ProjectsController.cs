﻿namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}