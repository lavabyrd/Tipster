using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tipster.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Configuration;
using System.Collections.Generic;


namespace Tipster.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewHome()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["OutputTest"] = TipsterAppBegin.Test();

            return View();
        }

        public IActionResult Upload()
        {
            ViewBag.Countries = ExampleMark.ArraySample();

            return View();
        }

        public IActionResult ViewAllData()
        {

            //List<string> courses;
            //foreach (var i in entries){
            //    courses.Add(i[0]);
            //}

            Reports.ReportAll();
            ViewBag.outr = Reports.ReportAll();

            //ViewBag.res = result.ToArray();


            //ViewBag.res = result;

            return View(Reports.ReportAll());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
