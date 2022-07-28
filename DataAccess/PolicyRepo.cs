using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
  public class PolicyRepo : IPolicy
    {
        // Dependency injection        
        private readonly easypickingsContext _dbContext;
        public PolicyRepo(easypickingsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Policy> GetAllPolicy()
        {
            return _dbContext.Policies.ToList();
        }

        public List<Policy> GetPolicyByID(int policyID)
        {
            return _dbContext.Policies.Where(p => p.PolicyId == policyID).ToList();
        }
        
        public List<Policy> GetPolicyByInsurance(int userID)
        {
            //return _dbContext.Policies.Include("Benefactors").Where((p => p.Benefactors.FirstOrDefault(u => u.UserId == userID) != null)).ToList();
            return _dbContext.Policies.Where(p => p.Insurance == userID).ToList();
        }

    
     public List<Policy> GetPolicyBycoverage(byte[] coverage)
        {
            return _dbContext.Policies.Where(p => p.Coverage == coverage).ToList();
        }
   }

}

