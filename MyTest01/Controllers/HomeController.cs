using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ActiveBusinessEdi.DataHelpers;
using Microsoft.AspNetCore.Http;

namespace ActiveBusinessEdi.Controllers
{
    public class HomeController : Controller
    {
        FileContentResult response;
        DataHandlers objdatahandlers = new DataHandlers();
        IList<OohDataExports> lstoohdataexports = new List<OohDataExports>();
        AppSettings objappsettings = new AppSettings();

        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("_Name") == null || HttpContext.Session.GetString("_Name") == "")
                {
                    return RedirectToAction("Login", "Account");
                }

                ViewData["UserName"] = HttpContext.Session.GetString("_Name").Trim();

                lstoohdataexports = objdatahandlers.GetOohDataExports();
                ViewBag.GridData = (lstoohdataexports).OrderByDescending(c => c.ID);
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult Index(string Type, string Status)
        {
            try
            {
                if (HttpContext.Session.GetString("_Name") == null || HttpContext.Session.GetString("_Name") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                ViewData["UserName"] = HttpContext.Session.GetString("_Name").Trim();
                var list = objdatahandlers.GetOohDataExports();
                var filterList = new List<OohDataExports>();

                if (Type == "All" && Status != "All")
                    filterList = list.Where(c => c.STATUS.ToLower().Contains(Status.ToLower())).OrderByDescending(c => c.ID).ToList();
                else if (Type != "All" && Status == "All")
                    filterList = list.Where(c => c.FILENAME.ToLower().Contains(Type.ToLower())).OrderByDescending(c => c.ID).ToList();
                else if (Type != "All" && Status != "All")
                    filterList = list.Where(c => c.FILENAME.ToLower().Contains(Type.ToLower()) && c.STATUS.ToLower().Contains(Status.ToLower())).OrderByDescending(c => c.ID).ToList();
                else
                    filterList = list.OrderByDescending(c => c.ID).ThenBy(c => c.FILENAME).ToList();

                ViewBag.GridData = filterList;
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DownloadFile(string fileName)
        {
            string username = "Kroger";
            if (HttpContext.Session.GetString("_Name") == null || HttpContext.Session.GetString("_Name") == "")
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                username = HttpContext.Session.GetString("_Name");
            }
            try
            {
                objappsettings = objdatahandlers.GetAppSettings();
                ActiveObjectStore.ContainerObject.ContainerData objcontainerdata = new ActiveObjectStore.ContainerObject.ContainerData();
                byte[] resget2 = objcontainerdata.GetContainerData(objappsettings.Url, objappsettings.UserId, objappsettings.Password,
                                objappsettings.ProjectId, objappsettings.ContainerName, objappsettings.Interface, objappsettings.Region, objappsettings.CatalogName, objappsettings.CatalogType,
                                fileName, "application/octet-stream", "GET");
                if (resget2 != null)
                {
                    response = null;
                    response = new FileContentResult(resget2, "application/octet-stream")
                    {
                        FileDownloadName = fileName
                    };
                    var clientIpConfig = HttpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',').FirstOrDefault();
                    username = username + "(" + clientIpConfig + ")";
                    objdatahandlers.UpdateDownloadDetails(username, fileName);
                }
                else
                {
                    ViewData["Message"] = "File null";
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

        public IActionResult dummy()
        {
            ViewData["UserName"] = "xcv";
            return View();
        }

        public IActionResult dummy1()
        {
            ViewData["UserName"] = "dum";
            return View();
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    //Logging the Exception
        //    filterContext.ExceptionHandled = true;

        //    filterContext.Result = Result;

        //}
    }
}

