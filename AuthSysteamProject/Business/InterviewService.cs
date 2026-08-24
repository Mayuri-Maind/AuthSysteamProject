using System.Collections.Generic;
using Sarthee.Services;
using Sarthee.Model;

namespace Sarthee.Business
{
    public class InterviewService : IInterviewService
    {
        public List<InterViewQuestion> GetQuestions()
        {
            // return an empty list to satisfy the interface; replace with real logic as needed
            return new List<InterViewQuestion>
            {
                new InterViewQuestion
                {
                    Id = 1,
                    Question = "What is your greatest strength?",
                    Category = "General"
                },
                new InterViewQuestion
                {
                    Id = 1,
                    Question = "What is Dependency Injection in .NET?",
                    Category = "C# / .NET"
                },
                new InterViewQuestion
                {
                    Id = 2,
                    Question = "What is MVC?",
                    Category = "ASP.NET MVC"
                },
                new InterViewQuestion
                {
                    Id = 3,
                    Question = "What is Entity Framework Core?",
                    Category = "Entity Framework"
                }
            };
        }
    }
}
