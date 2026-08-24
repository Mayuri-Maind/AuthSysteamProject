using Microsoft.AspNetCore.Mvc;
using Sarthee.Services;

namespace Sarthee.Controllers
{
    // ============================================================
    // API CONTROLLER
    // ============================================================
    //
    // [ApiController] tells ASP.NET Core that this is an API
    // controller rather than a normal MVC View controller.
    //
    // This is important because our frontend is React.
    //
    [ApiController]


    // ============================================================
    // ROUTE
    // ============================================================
    //
    // "api/[controller]" uses the controller name.
    //
    // InterviewController
    //        ↓
    // /api/interview
    //
    [Route("api/[controller]")]
    public class InterviewController : ControllerBase
    {
        // ========================================================
        // INTERVIEW SERVICE
        // ========================================================
        //
        // This variable will hold our Interview Service.
        //
        // We don't create InterviewService ourselves.
        //
        // ASP.NET Core Dependency Injection will provide it.
        //
        private readonly IInterviewService _interviewService;


        // ========================================================
        // CONSTRUCTOR INJECTION
        // ========================================================
        //
        // We ask ASP.NET Core:
        //
        // "Give me an IInterviewService."
        //
        // Program.cs contains:
        //
        // builder.Services.AddScoped
        //     <IInterviewService, InterviewService>();
        //
        // Therefore ASP.NET Core knows that whenever this
        // controller asks for IInterviewService, it should
        // create an InterviewService object.
        //
        public InterviewController(
            IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }


        // ========================================================
        // GET QUESTIONS
        // ========================================================
        //
        // This endpoint will be:
        //
        // GET
        // /api/interview/questions
        //
        // React will call this endpoint.
        //
        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            // Call our service.
            //
            // The controller does NOT contain the interview
            // business logic.
            //
            // It simply asks the service for the questions.
            var questions = _interviewService.GetQuestions();


            // Return the questions as JSON.
            //
            // ASP.NET Core automatically converts the C#
            // object into JSON.
            return Ok(questions);
        }
    }
}