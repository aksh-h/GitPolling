using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace DemoGenGitPolling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string contact = System.IO.File.ReadAllText(Server.MapPath("~") + @"\Template\Contact.json");
            if (contact != "")
            {
                JObject obj = new JObject();
                obj = JsonConvert.DeserializeObject<JObject>(contact);
                string name = obj["Name"].ToString();
                string company = obj["Company"].ToString();
                ViewBag.Name = name;
                ViewBag.Company = company;
            }
            return View();
        }
    }
}