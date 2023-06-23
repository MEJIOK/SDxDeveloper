using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SDxDeveloper.Services.API
{
    public sealed class ODataProvider
    {
        private readonly HttpClient _DefaultServer;

        public ODataProvider(string defaultServerUrl, string authToken, string? defaultConfig = null)
        {
            _DefaultServer = new() { BaseAddress = new Uri(defaultServerUrl) };
            _DefaultServer.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            if (defaultConfig != null) _DefaultServer.DefaultRequestHeaders.Add("SPFConfigUID", defaultConfig);

            //var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging);
            //engine.Execute(File.ReadAllText("ODataProvider.js"));
            //var result = engine.Script.ODataProvider("qwe", null);
            //MessageBox.Show(result.ToString());
        }


        public async Task<string> GetObjectByOBID(string obid)
        {
            using HttpResponseMessage response = await _DefaultServer.GetAsync($"BGPP2Server/api/v2/SDA/Objects('{obid}')");
            return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        }
    }
}
