using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.ClearScript.V8;

namespace SDxDeveloper.Services.API
{
    public sealed class ODataProvider
    {
        public ODataProvider()
        {
            var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging);
            engine.Execute(File.ReadAllText("ODataProvider.js"));
            var result = engine.Script.ODataProvider("qwe", null);
            MessageBox.Show(result.ToString());
        }
    }
}
