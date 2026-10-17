using Application.Commands.UserTestCommand;
using Application.Queries.TrainingParticipantQueries;
using Application.Queries.TrainingQueries;
using Application.Queries.TrainingTestQueries;
using Domain.DTOs;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebUI.Areas.ITrainings.Pages.Admin
{
    public class TrainingUsersAssessmentModel : PageModel
    {


        private readonly IMediator _mediator;

        public TrainingUsersAssessmentModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnGet(long tid)
        {
            TrainingId = tid;
        } 
        public TrainingDto Training { get; set; }
        public List<TrainingTest> Questions { get; set; }
        public Dictionary<long, int> CorrectAnswers { get; set; } = new();

        [BindProperty]
        public long TrainingId { get; set; }

        public async Task<IActionResult> OnPostAsync(long tid, int xty)
        {
            // Get the training details
            Training = await _mediator.Send(new GetByIdAndCountTrainingQuery(tid));
            if (Training == null)
            {
                TempData["error"] = "Training not found.";
                return RedirectToPage("./Index");
            }

            var users = await _mediator.Send(new ListParticipantByTrainingIdQuery(tid));
            // Get all users in the training
             

            // Get all test questions for the training
            Questions = await _mediator.Send(new ListTrainingTestQuery());
            if (xty == 0)
            {

                Questions = Questions.Where(x => x.TrainingTestType == EnumStatus.TrainingTestType.PreTest).ToList();
            }
            else if (xty == 2)
            {

                Questions = Questions.Where(x => x.TrainingTestType == EnumStatus.TrainingTestType.PostTest).ToList();

            }

            // Store correct answers
            foreach (var question in Questions)
            {
                CorrectAnswers[question.Id] = question.CorrectAnswer;
            }

            // Prepare automatic test submissions
            var allSubmissions = new List<(long questionId, int answer, string userId, long trainingId)>();
            foreach (var user in users)
            {
                var userAnswers = Questions.Select(q => (q.Id, CorrectAnswers[q.Id], user.Id, tid)).ToList();
                allSubmissions.AddRange(userAnswers);
            }

            // Submit the assessments
            if (allSubmissions.Any())
            {
                var command = new UpdateAssestmentCommand(allSubmissions);
                await _mediator.Send(command);
                TempData["success"] = "All assessments have been successfully submitted with 100% accuracy.";
            }
            else
            {
                TempData["error"] = "No assessments were submitted.";
            }

            return RedirectToPage("./TrainingUsersAssessment", new { tid });
        }
    }
}
