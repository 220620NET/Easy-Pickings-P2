using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _dbContext.Policy.ToList();
        }

        public List<Policy> GetPolicyByPolicyID(int policyID)
        {
            return _dbContext.Tickets.Where(p => p.userIDFK == policyID).ToList();
        }
        
        public List<Policy> GetPolicyByuserID(int userID)
        {
            return _dbContext.Tickets.Where(p => p.userID == userID).ToList();
        }

    
     public List<Policy> GetPolicyBycoverage(FileStream coverage)
        {
            return _dbContext.Tickets.Where(p => p.coverage == coverage).ToList();
        }
   }

}

