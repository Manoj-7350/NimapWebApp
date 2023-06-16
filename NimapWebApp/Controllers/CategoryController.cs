using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NimapWebApp.Models;
using NimapWebApp.Repository;

namespace NimapWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View("Create");
        }


        public IActionResult GetListPagination(int offseVal, int rowlim)
        {


            if (offseVal == 0)
            {
                ViewBag.data = "myHref1";
            }
            else if (offseVal == 10)
            {
                ViewBag.data = "myHref2";
            }
            else if (offseVal == 20)
            {
                ViewBag.data = "myHref3";
            }
            else if (offseVal == 30)
            {
                ViewBag.data = "myHref4";
            }
            else if (offseVal == 40)
            {
                ViewBag.data = "myHref5";
            }
            else if (offseVal == 50)
            {
                ViewBag.data = "myHref6";
            }
            else if (offseVal == 60)
            {
                ViewBag.data = "myHref7";
            }





            NimapRepo objclsproduct = new NimapRepo();
            var abc1 = objclsproduct.GetAllProduct(offseVal, rowlim);
            return View("GetList", abc1);
        }
        public IActionResult Create(clsProduct pro)
        {
            NimapRepo objclsproduct = new NimapRepo();
            var abc = objclsproduct.AddProduct(pro);
            //  var aa = Productid;
            return View();
        }


        public IActionResult Update(clsProduct pro)
        {
            NimapRepo objclsproduct = new NimapRepo();
            var abc = objclsproduct.UpdateProduct(pro);

            if (abc)
            {
                ViewBag.SuccessMessage = "Data Successfully saved...!";
            }
            else
            {
                ViewBag.SuccessMessage = "Data Not saved...!";
            }
            //  var aa = Productid;
            return View();
        }

        public IActionResult Details(int id)
        {
            NimapRepo objclsproduct = new NimapRepo();
            var abc = objclsproduct.DetailsOfProduct(id);

            //  var aa = Productid;
            return View("Update", abc);
        }


        public IActionResult GetList()
        {
            ViewBag.data = "myHref1";
            NimapRepo objclsproduct = new NimapRepo();
            var abc = objclsproduct.GetAllProduct(0, 10);
            //  var aa = Productid;
            return View(abc);
        }

        public IActionResult Delete(int id)
        {
            NimapRepo objclsproduct = new NimapRepo();
            var abc = objclsproduct.DeleteProduct(id);
            //  var aa = Productid;
            var abc123 = objclsproduct.GetAllProduct();
            return View("GetList", abc123);
        }
    }
}
