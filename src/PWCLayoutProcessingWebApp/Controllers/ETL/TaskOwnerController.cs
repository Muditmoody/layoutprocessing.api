using System.Data;
using Microsoft.AspNetCore.Mvc;
using PWCLayoutProcessingWebApp.Data;
using PWCLayoutProcessingWebApp.Models;
using PWCLayoutProcessingWebApp.Models.ETL;
using PWCLayoutProcessingWebApp.BusinessLogic;
using Import = PWCLayoutProcessingWebApp.Models.Import;
using Extract = PWCLayoutProcessingWebApp.Models.Extract;

namespace PWCLayoutProcessingWebApp.Controllers.ETL
{
    [ApiController]
    [Route("api/etl/[controller]")]
    public class TaskOwnerController : ControllerBase
    {
        private readonly ILogger<TaskOwnerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DatabaseProvider _databaseProvider;
        private readonly QueryBuilder _queryBuilder;
        private readonly LayoutProcessingDbContext _dbContext;

        private readonly bool _useQuery;

        public TaskOwnerController(ILogger<TaskOwnerController> logger, IConfiguration configuration,
            DatabaseProvider databaseProvider, QueryBuilder queryBuilder,
            LayoutProcessingDbContext dbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _databaseProvider = databaseProvider;
            _queryBuilder = queryBuilder;
            _dbContext = dbContext;
            var section = _configuration.GetSection("FeatureFlags");
            if (section!.Exists() && section.GetChildren().Any(item => item.Key == "UseQuery"))
            {
                _useQuery = _configuration.GetValue<bool>("FeatureFlags:UseQuery");
            }
        }

        [HttpGet("GetTaskOwners")]
        public IEnumerable<Extract.ExtractTaskOwner> GetTaskOwners()
        {
            _logger.LogDebug("Get Task Owner info");
            var result = default(IEnumerable<TaskOwner>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskOwner.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskOwner.Map);
            }
            else
            {
                result = _dbContext.TaskOwners.ToList();
            }

            return result?.Select(Extract.ExtractTaskOwner.Map);
        }

        [HttpGet("GetTaskOwnerByCdode")]
        public IEnumerable<Extract.ExtractTaskOwner> GetTaskOwnersByCode([FromQuery] IEnumerable<string> name)
        {
            _logger.LogDebug("Get Task Owner  info");

            var result = default(IEnumerable<TaskOwner>);
            if (_useQuery)
            {
                var sql = _queryBuilder.GetQueryFromResouce("TaskOwner.sql");
                result = _databaseProvider.ExecuteQuery(sql, TaskOwner.Map)
                                          .Where(p => name.Contains(p.TaskOwnerCode))
                                          .ToList();
            }
            else
            {
                result = _dbContext.TaskOwners
                                   .Where(p => name.Contains(p.TaskOwnerCode))
                                   .ToList();
            }

            return result?.Select(Extract.ExtractTaskOwner.Map);
        }

        [HttpPost("AddTaskOwner")]
        public ActionResult AddTaskOwners(IEnumerable<Import.ImportTaskOwner> owners)
        {
            //if (owners is not null && owners.Any())
            //{
            //    foreach (TaskOwner item in owners)
            //    {
            //        if (!_dbContext.TaskOwners.Any(p => p.TaskOwnerCode == item.TaskOwnerCode))
            //        {
            //            _dbContext.TaskOwners.Add(item);
            //        }
            //        else if (_dbContext.TaskOwners.Any(p => p.TaskOwnerCode == item.TaskOwnerCode || p.TaskOwnerId == item.TaskOwnerId))
            //        {
            //            var owner = _dbContext.TaskOwners.FirstOrDefault(p => p.TaskOwnerCode == item.TaskOwnerCode);
            //            _dbContext.Entry(owner).CurrentValues.SetValues(item);
            //        }
            //    }

            //    var affectedItems = _dbContext.SaveChanges();
            //}

            Func<TaskOwner, Import.ImportTaskOwner, bool> finder = (existingItem, importItem) =>
            {
                return existingItem.TaskOwnerCode == importItem.TaskOwnerCode;
            };

            Func<Import.ImportTaskOwner, TaskOwner, TaskOwner> transformer = (importItem, extistingItem) =>
            {
                if (extistingItem is null)
                {
                    return new TaskOwner
                    {
                        TaskOwnerId = 0,
                        TaskOwnerCode = importItem.TaskOwnerCode
                    };
                }
                else
                {
                    return new TaskOwner
                    {
                        TaskOwnerId = extistingItem.TaskOwnerId,
                        TaskOwnerCode = importItem.TaskOwnerCode
                    };
                }
            };

            var result = EntityUtil.AddEntity(_dbContext, _dbContext.TaskOwners, owners, finder, transformer, true);

            return result switch
            {
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<bool>)) => Ok(),
                Result r when r.GetType().IsAssignableFrom(typeof(Result.Ok<int>)) => Ok(r),
                Result.Error error => Ok(error),
                _ => throw new NotImplementedException(),
            };

        }

        #region commeted code for Running python script

        /*
        [HttpPost("RunScript")]
        public void RunScript()
        {
            //ScriptEngine engine = Python.CreateEngine();
            //var paths = engine.GetSearchPaths();
            //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib//site-packages");
            //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib");
            //engine.SetSearchPaths(paths);

            ////var scope = engine.ExecuteFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");
            //var file= engine.CreateScriptSourceFromFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");
            //var scope = engine.CreateScope();

            //file.Execute(scope);
            //dynamic x = scope.GetVariable("fu");
            //var b = x();

            //var a = "";

            //ProcessStartInfo start = new ProcessStartInfo(@"C:\Users\Mudit Aggarwal\AppData\Local\Programs\Python\Python310\python.exe", @"C:\Users\Mudit Aggarwal\Downloads\test.py");
            //ProcessStartInfo start = new ProcessStartInfo(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39\Scripts\ipython.exe", @"C:\Users\Mudit Aggarwal\Downloads\test.py");
            ProcessStartInfo start = new ProcessStartInfo(@"C:\Users\Mudit Aggarwal\.conda\envs\capstone\python.exe", @"C:\Users\Mudit Aggarwal\Downloads\test.py");

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.RedirectStandardError = true;

            using (Process process = Process.Start(start))
            {
                {
                    var read = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    Console.Write(read);
                }
            }
        }
        [HttpPost("RunScript1")]
        public void RunScript_1()
        {
            ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
            var paths = engine.GetSearchPaths();
            //paths.Add("C://Users//Mudit Aggarwal//AppData//Roaming//Python//Python39//site-packages");
            //paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39");
            //paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39\Scripts");

            //paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39\site-packages\visions\backends");
            paths.Add(@"C:\Users\Mudit Aggarwal\.conda\envs\capstone");
            paths.Add(@"C:\Users\Mudit Aggarwal\.conda\envs\capstone\Lib");
            paths.Add(@"C:\Users\Mudit Aggarwal\.conda\envs\capstone\Lib\site-packages");
            //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib");
            //paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python310\Scripts");
            //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib//site-packages");
            engine.SetSearchPaths(paths);

            //var scope = engine.ExecuteFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");
            var file = engine.CreateScriptSourceFromFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");
            var scope = engine.CreateScope();

            //file.GetCodeLines(1, 100);
            file.Execute(scope);
            dynamic x = scope.GetVariable("fu");
            var b = x();

            var a = "";
        }

        [HttpPost("RunScript2")]
        public void RunScript_2()
        {
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", @"C:\Users\Mudit Aggarwal\AppData\Local\Programs\Python\Python310.dll");

            using (Py.GIL())
            {
                ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
                var paths = engine.GetSearchPaths();
                paths.Add("C://Users//Mudit Aggarwal//AppData//Roaming//Python//Python39//site-packages");
                paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39");
                //paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python39\site-packages\visions\backends");
                //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib");
                paths.Add(@"C:\Users\Mudit Aggarwal\AppData\Roaming\Python\Python310\Scripts");
                //paths.Add("C://Users//Mudit Aggarwal//AppData//Local//Programs//Python//Python310//Lib//site-packages");
                engine.SetSearchPaths(paths);

                //var scope = engine.ExecuteFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");
                var file = engine.CreateScriptSourceFromFile(@"C:\Users\Mudit Aggarwal\Downloads\test.py");

                var code = file.Compile().ToString();
                PythonEngine.RunSimpleString(code);
            }
        }
        */

        #endregion commeted code for Running python script
    }
}