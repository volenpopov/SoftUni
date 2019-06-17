using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        IEnumerable<Problem> GetAllProblems();

        bool CreateProblem(string userId, string name, int points);

        Problem GetCurrentProblemOrNull(string problemId);
    }
}
