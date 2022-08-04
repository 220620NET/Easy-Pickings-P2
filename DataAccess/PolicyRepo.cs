﻿using NewModels;
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
            return _dbContext.policies.AsNoTracking().ToList();
        }
         /// <summary>
         /// will grab all policy related to the ID
         /// </summary>
         /// <param name="policyID">policyID to sort by</param>
         /// <returns>List of aall policy from a particular ID</returns>
        public List<Policy> GetPolicyByID(int policyID)
        {
            return _dbContext.policies.Where(p => p.policyID == policyID).ToList();
        }
        /// <summary>
        /// Will grab all policy related to the insurance
        /// </summary>
        /// <param name="userID">userID to sort by</param>
        /// <returns>The specific policy by insurance</returns>
        public List<Policy> GetPolicyByInsurance(int userID)
        {
            return _dbContext.policies.Where(p => p.insurance == userID).ToList();
        }
        /// <summary>
        /// Will grab all policy related to the coverage
        /// </summary>
        /// <param name="coverage">specify the coverage</param>
        /// <returns>List of all coverage from a specific coverage</returns>
        public List<Policy> GetPolicyBycoverage(string coverage)
        {
            return _dbContext.policies.Where(p => p.coverage == coverage).ToList();
        }
         /// <summary>
         /// Will create a new entry for a Policy in the policy table in the database
         /// </summary>
         /// <param name="policy">new policy</param>
         /// <returns>new policy</returns>
    public Policy CreatePolicy(Policy policy)
        { 
            _dbContext.policies.Add(policy);
            Finish();
            return policy ?? throw new NotImplementedException();
        }
        /// <summary>
        /// This will remove a policy from the discussion board
        /// </summary>
        /// <param name="policyID">Policy ID to delete</param>
        /// <returns>Policy deleted</returns>
        public Policy DeletePolicy(int policyID)
        {
            Policy policyToDelete =_dbContext.policies.FirstOrDefault(policy=>policy.policyID==policyID)??throw new NotImplementedException();
            _dbContext.policies.Remove(policyToDelete);
            Finish();
            return policyToDelete ?? throw new NotImplementedException();
        }
        /// <summary>
        /// Will update a policy
        /// </summary>
        /// <param name="policy">policy to update</param>
        /// <returns>updated policy</returns>
         public Policy UpdatePolicy(Policy policy)
        {
            _dbContext.policies.Update(policy);
            Finish();
            return policy ?? throw new NotImplementedException();
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


