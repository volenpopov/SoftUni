using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public bool CreateProblem(string userId, string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
                UserId = userId
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<Problem> GetAllProblems()
        {           
            return this.db.Problems
                .Include(p => p.Submissions)
                .AsEnumerable();
        }

        public Problem GetCurrentProblemOrNull(string problemId)
        {
            return this.db.Problems.Find(problemId);
        }
    }
}
