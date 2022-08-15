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
      /// <summary>
      /// Will get all policy from the database
      /// </summary>
      /// <returns> All Policy </returns>
        public List<Policy> GetAllPolicy()
        {
            return _dbContext.Policies.AsNoTracking().ToList()??throw new NotImplementedException();
        }
         /// <summary>
         /// will grab all policy related to the ID
         /// </summary>
         /// <param name="policyID">policyID to sort by</param>
         /// <returns>List of aall policy from a particular ID</returns>
        public Policy GetPolicyByID(int policyID)
        {
            return _dbContext.Policies.FirstOrDefault(p => p.policyID == policyID) ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will grab all policy related to the insurance
        /// </summary>
        /// <param name="userID">userID to sort by</param>
        /// <returns>The specific policy by insurance</returns>
        public List<Policy> GetPolicyByInsurance(int userID)
        {
            return _dbContext.Policies.Where(p => p.insurance == userID).ToList() ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will grab all policy related to the coverage
        /// </summary>
        /// <param name="coverage">specify the coverage</param>
        /// <returns>List of all coverage from a specific coverage</returns>
        public List<Policy> GetPolicyBycoverage(string coverage)
        {
            return _dbContext.Policies.Where(p => p.coverage == coverage).ToList() ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will create a new entry for a Policy in the policy table in the database
        /// </summary>
        /// <param name="policy">new policy</param>
        /// <returns>new policy</returns>
        public Policy CreatePolicy(Policy policy)
        { 
            _dbContext.Policies.Add(policy);
            Finish();
            return policy ?? throw new NotImplementedException();
        }
        /// <summary>
        /// This will remove a policy from the discussion board
        /// </summary>
        /// <param name="policyID">Policy ID to delete</param>
        /// <returns>Policy deleted</returns>
        public bool DeletePolicy(int policyID)
        {
            Policy? policyToDelete = _dbContext.Policies.FirstOrDefault(ticket => ticket.policyID == policyID);
            if (policyToDelete != null)
            {
                _dbContext.Entry(policyToDelete).State = EntityState.Deleted;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Will update a policy
        /// </summary>
        /// <param name="policy">policy to update</param>
        /// <returns>updated policy</returns>
         public Policy UpdatePolicy(Policy policy)
        {
            try
            {
                Policy? p = _dbContext.Policies.FirstOrDefault(t => t.policyID == policy.policyID);
                p.insurance = policy.insurance != 0 ? policy.insurance : p.insurance;                 
                p.coverage = policy.coverage != "" ? policy.coverage : p.coverage;
                Finish();
                return p ?? throw new NotImplementedException();

            }
            catch (ArgumentNullException)
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Persist changes and clear the tracker
        /// </summary>
         protected void Finish( )
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
    }

}


