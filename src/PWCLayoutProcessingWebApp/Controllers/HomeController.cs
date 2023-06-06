using Microsoft.AspNetCore.Mvc;
using PWCLayoutProcessingWebApp.Models.ETL;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PWCLayoutProcessingWebApp.BusinessLogic;
using PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly IActionDescriptorCollectionProvider _actionProvider;
        private readonly string _baseUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="actionProvider">The action provider.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="databaseProvider">The database provider.</param>
        /// <param name="queryBuilder">The query builder.</param>
        public HomeController(IActionDescriptorCollectionProvider actionProvider, ILogger<HomeController> logger, IConfiguration configuration, DatabaseProvider databaseProvider, QueryBuilder queryBuilder)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
            _actionProvider = actionProvider;
            _baseUrl = _configuration.GetConnectionString("BaseUrl");
        }

        /// <summary>
        /// Entry point for controller
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            var routes = _actionProvider.ActionDescriptors.Items.Where(x => x.AttributeRouteInfo == null);
            var paths = routes.Select(r =>
            {
                var a = r as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
                return $"{_baseUrl}/{a.ControllerName}/{a.ActionName}";
            }
            );

            var routes2 = _actionProvider.ActionDescriptors.Items
                                         .Where(x => x.AttributeRouteInfo != null)
                                         .Where(x => x.Parameters.Count <= 0);
            var paths2 = routes2.Select(r =>
            {
                var a = r as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
                return $"{_baseUrl}/{a.AttributeRouteInfo.Template}";
            }
            );

            paths = paths.Concat(paths2);

            var dict = paths.Select((value, index) => new { index, value }).ToDictionary(i => $"Query {i.index} - {i.value.Split('/').Last()}", i => i.value);
            return View(dict);
        }

        /// <summary>
        /// Views the cause code.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult ViewCauseCode()
        {
            var returnObj = new List<CauseCode>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/etl/CauseCode/GetCauseCodes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CauseCode>>(data);
                }
            }
            ViewData["Title"] = "CauseCode";
            return View("ViewP", returnObj);
        }

        /// <summary>
        /// Views the group code.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult ViewGroupCode()
        {
            var returnObj = new List<CodeGroup>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/etl/CodeGroup/GetGroupCodes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CodeGroup>>(data);
                }
            }
            ViewData["Title"] = "CodeGroup";
            return View("ViewP", returnObj);
        }

        /// <summary>
        /// Views the task code.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult ViewTaskCode()
        {
            var returnObj = new List<ExtractTaskCode>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/etl/TaskCode/GetTaskCodes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    returnObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExtractTaskCode>>(data);
                }
            }
            ViewData["Title"] = "TaskCode";
            return View("ViewP2", returnObj);
        }
    }
}