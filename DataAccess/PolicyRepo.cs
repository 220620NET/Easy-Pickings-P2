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
   
    public Policy CreatePolicy(Policy policy)
        { 
            _dbContext.policies.Add(policy);
            Finish();
            return policy ?? throw new NotImplementedException();
        }
        public Policy DeletePolicy(int policyID)
        {
            Policy policyToDelete =_dbContext.policies.FirstOrDefault(policy=>policy.policyID==policyID)??throw new NotImplementedException();
            _dbContext.policies.Remove(policyToDelete);
            Finish();
            return policyToDelete ?? throw new NotImplementedException();
        }
         public Policy UpdatePolicy(Policy policy)
        {
            _dbContext.policies.Update(policy);
            Finish();
            return policy ?? throw new NotImplementedException();
        }
         protected void Finish( )
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }

}


