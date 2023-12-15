using Foog.Core.Data;
using Foog.Core.Permission;
using Foog.Service.Sys;
using Foog.Service.Sys.Dto.Demo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foog.Api.Controllers
{
    /// <summary>
    /// Demo
    /// </summary>
    [Authorize]
    public class DemoController : BaseController
    {
        private readonly IDemoService _demoService;

        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        //[HttpPost]
        //public Task<OperationResult> AddUserAsync(AddDemoInputDto input)
        //{
        //    return _demoService.AddUserAsync(input);
        //}

        [HttpGet]
        [Permission("App.Code")]
        public OperationResult GetAsync()
        {
            return R.Ok();
        }
        [HttpGet]
        [Permission("App.Code1")]
        public OperationResult Get1Async()
        {
            return R.Ok();
        }
        [HttpGet]
        [Permission("App.Code3")]
        public OperationResult Get3Async()
        {
            return R.Ok();
        }

        [HttpGet]
        public OperationResult Get4Async()
        {
            return R.Ok();
        }
    }
}
