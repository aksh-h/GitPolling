using System.Diagnostics;
using System.Web.Hosting;
using System.Web.Http;

namespace DemoGenGitPolling.Controllers
{
    public class GitPullController : ApiController
    {
        [HttpGet]
        [Route("api/gitpull")]
        public void ExecuteCommand()
        {
            string command = System.IO.Path.GetFullPath(HostingEnvironment.MapPath("~") + @"\Batch\GitPull.bat");

            string commandTxt = System.IO.File.ReadAllText(command);
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.Close();
        }
    }
}
