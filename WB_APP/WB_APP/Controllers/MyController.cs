using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WB_APP.Models;

namespace WB_APP.Controllers
{
    public class MyController : Controller
    {
        public List<Vegetables> GetVegetablesList()
        {
            var plants = new List<Vegetables>();
            string path = "Data/data.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            string[] parts;
            foreach (string line in lines)
            {
                parts = line.Split(' ');
                plants.Add(new Vegetables { Name = parts[0], Price = double.Parse(parts[1]) });
            }
            return plants;
        }

        public IActionResult FirstViewMethod()
        {
            List<Vegetables> vegetables = GetVegetablesList();
            return View(vegetables);

        }
        public ActionResult SecondViewMethod()
        {
            var vegetables = GetVegetablesList().OrderBy(x => x.Name).ToList();
            return View(vegetables);
        }
        public ActionResult ThirdViewMethod()
        {
            var vegetables = GetVegetablesList().OrderBy(x => x.Name).ToList();
            return View(vegetables);
        }
    }
}
