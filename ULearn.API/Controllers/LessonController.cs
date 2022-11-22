using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ULearn.API.Attributes;
using ULearn.Core.Manager.Interfaces;
using ULearn.ModelView.Request;

namespace ULearn.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    public class LessonController : ApiBaseController
    {
        private ILessonManager _LessonManager;
        private readonly ILogger<UserController> _logger;

        public LessonController(ILessonManager LessonManager, ILogger<UserController> logger)
        {
            _LessonManager = LessonManager;
            _logger = logger;
        }

        [Route("api/v{version:apiVersion}/create")]
        [HttpPost]
        [MapToApiVersion("1")]
        [Authorize]
        [ULearnAuthorize(Permissions = "Create new Lesson")]
        public IActionResult CreateLesson(LessonRequest LessonRequest)
        {
            var result = _LessonManager.CreateLesson(LoggedInUser, LessonRequest);
            return Ok(result);
        }

        [Route("api/v{version:apiVersion}/getAll")]
        [HttpGet]
        [ULearnAuthorize(Permissions = "View All Lesson")]
        [MapToApiVersion("1")]
        public IActionResult GetLessons(int page = 1,
                                      int pageSize = 5,
                                      string sortColumn = "",
                                      string sortDirection = "ascending",
                                      string searchText = "")
        {
            var result = _LessonManager.GetLessons(page, pageSize, sortColumn, sortDirection, searchText);
            return Ok(result);
        }

        [Route("api/v{version:apiVersion}/get/{id}")]
        [HttpGet]
        [MapToApiVersion("1")]
        [Authorize]
        [ULearnAuthorize(Permissions = "View All Lesson,View Lesson")]
        public IActionResult GetLesson(int id)
        {
            var result = _LessonManager.GetLesson(LoggedInUser, id);
            return Ok(result);
        }

        [Route("api/v{version:apiVersion}/delete/{id}")]
        [HttpDelete]
        [MapToApiVersion("1")]
        [Authorize]
        [ULearnAuthorize(Permissions = "Delete Lesson")]
        public IActionResult ArchiveLesson(int id)
        {
            _LessonManager.ArchiveLesson(LoggedInUser, id);
            return Ok();
        }

        [Route("api/v{version:apiVersion}/update")]
        [HttpPut]
        [MapToApiVersion("1")]
        [Authorize]
        [ULearnAuthorize(Permissions = "Edit Lesson")]
        public IActionResult PutLesson(LessonRequest LessonRequest)
        {
            var result = _LessonManager.PutLesson(LoggedInUser, LessonRequest);
            return Ok(result);
        }
    }
}
