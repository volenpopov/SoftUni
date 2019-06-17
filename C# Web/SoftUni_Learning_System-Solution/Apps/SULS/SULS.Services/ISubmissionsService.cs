using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        bool CreateSubmission(string userId, string problemId, int problemMaxPoints, string code);

        bool DeleteSubmission(string useId, string submissionId);

        Problem GetProblemOfSubmission(string submissionId);
        IEnumerable<Submission> GetProblemSubmissions(string problemId);
    }
}
