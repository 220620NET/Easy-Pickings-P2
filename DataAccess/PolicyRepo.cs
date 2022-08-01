using NewModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
  public class PolicyRepo : IPolicy
    {
        // Dependency injection        
        private readonly InsuranceDbContext _dbContext;
        public PolicyRepo(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Policy> GetAllPolicy()
        {
            return _dbContext.policies.AsNoTracking().ToList();
        }

        public List<Policy> GetPolicyByID(int policyID)
        {
            return _dbContext.policies.Where(p => p.policyID == policyID).ToList();
        }
        
        public List<Policy> GetPolicyByInsurance(int userID)
        {
            return _dbContext.policies.Where(p => p.insurance == userID).ToList();
        }

    
        public List<Policy> GetPolicyBycoverage(string coverage)
        {
            return _dbContext.policies.Where(p => p.coverage == coverage).ToList();
        }
   }

}

