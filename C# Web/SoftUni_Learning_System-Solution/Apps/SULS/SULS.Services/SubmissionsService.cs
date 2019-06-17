using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;

        public SubmissionsService(SULSContext db)
        {
            this.db = db;
        }

        public bool CreateSubmission(string userId, string problemId, int problemMaxPoints, string code)
        {
            var submission = new Submission
            {
                Code = code,
                AchievedResult = new Random().Next(0, problemMaxPoints),
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,              
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            return true;
        }

        public bool DeleteSubmission(string userId, string submissionId)
        {
            var submission = this.db.Submissions
                .FirstOrDefault(s => s.Id == submissionId && s.User.Id == userId);

            if (submission == null)
            {
                return false;
            }

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();

            return true;
        }

        public Problem GetProblemOfSubmission(string submissionId)
        {
            return this.db.Submissions
                    .Include(s => s.Problem)
                    .FirstOrDefault(s => s.Id == submissionId)
                    .Problem;
        }

        public IEnumerable<Submission> GetProblemSubmissions(string problemId)
        {
            return this.db.Submissions
                .Where(s => s.ProblemId == problemId)
                .Include(s => s.User)
                .AsEnumerable();
        }
    }
}
