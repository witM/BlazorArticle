using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    public class Runtime
    {

        /// <summary>
        /// Determines the environment of the running app. Return true when application is running in the browser as webassembly.<br/>
        /// <br/>
        /// This is short hand calling: RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"))
        /// </summary>
        public static bool IsWebAssembly { get { return RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")); } }
    }
}
