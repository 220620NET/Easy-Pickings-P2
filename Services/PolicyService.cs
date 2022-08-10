using DataAccess;
using NewModels;
using CustomExceptions;

namespace Services;

public class PolicyService
{
    private readonly IPolicy _repo;
    private readonly IUserRepo _repos;
    public PolicyService(IPolicy repo, IUserRepo repos)
    {
        _repo = repo;
        _repos = repos;
    }
    /// <summary>
    /// wiil get all policy
    /// </summary>
    /// <param name="policyID">policyID itself</param>
    /// <returns>related policy</returns>
    /// <exception cref="NotImplementedException">There is no policy related to that ID</exception>
    public Policy GetPolicyByID(int policyID)
    {
       // return _repo.GetPolicyByID(policyID)?? throw new NotImplementedException();
        try
        {
            List<Policy> all = _repo.GetAllPolicy();
            bool there = true;
            foreach (Policy policy in all)
            {
                if (policyID != policy.policyID)
                {
                    there = false;
                }
            }
            if (!there)
            {
                throw new PolicyNotAvailable();
            }
            return _repo.GetPolicyByID(policyID);
        }
        catch (PolicyNotAvailable)
        {
            throw new PolicyNotAvailable();
        }
        catch (NotImplementedException)
        {
            throw new PolicyNotAvailable();
        }
    }
    /// <summary>
    /// Will get all policy
    /// </summary>
    /// <returns>all policy</returns>
    /// <exception cref="NotImplementedException">There are no policy</exception>
     public List<Policy> GetAllPolicy()
    {
        return _repo.GetAllPolicy()?? throw new NotImplementedException();
    }
    /// <summary>
    /// Will return all policy related to a particular insurance
    /// </summary>
    /// <param name="insurance">insurance itself</param>
    /// <returns>a list of all ralated insurace </returns>
    /// <exception cref="NotImplementedException">There are no policy related to that insurance</exception>
    public List<Policy> GetPolicyByInsurance(int insurance)
    {
       // return _repo.GetPolicyByInsurance(insurance)?? throw new NotImplementedException();
        try
        {
            List<User> all = _repos.GetAllUsers();
            bool there = true;
            foreach (User policy in all)
            {
                if (insurance != policy.userID)
                {
                    there = false;
                }
            }
            if (!there)
            {
                throw new InvalidUserException();
            }
            return _repo.GetPolicyByInsurance(insurance);
        }
        catch (InvalidUserException)
        {
            throw new InvalidUserException();
        }
        catch (PolicyNotAvailable)
        {
            throw new PolicyNotAvailable();
        }
    }
    /// <summary>
    /// will get all policy from the specific coverage
    /// </summary>
    /// <param name="coverage">The coverage itself</param>
    /// <returns>coverage itself</returns>
    public List<Policy> GetPolicyBycoverage(string coverage)
    {
        return _repo.GetPolicyBycoverage(coverage)?? throw new NotImplementedException();
    }
    /// <summary>
    /// will create a policy
    /// </summary>
    /// <param name="policy">Active policy</param>
    /// <returns>The newly created policy</returns>
    /// <exception cref="NotImplementedException">That policy couldn't be created</exception>
     public Policy CreatePolicy(Policy policy)
    {
       // return _repo.CreatePolicy(policy) ?? throw new NotImplementedException();
        try
        {
            List<Policy> policyU = GetPolicyByInsurance(policy.insurance);
            return _repo.CreatePolicy(policy);
        }
        catch (InvalidUserException)
        {
            throw new InvalidUserException();
        }
    }
    /// <summary>
    /// wiil update a policy
    /// </summary>
    /// <param name="policy">Active policy that needs to update</param>
    /// <returns>updated policy</returns>
    /// <exception cref="NotImplementedException">That policy could not be updated</exception>
    public Policy UpdatePolicy(Policy policy)
    {
       // return _repo.UpdatePolicy(policy) ?? throw new NotImplementedException();
        try
        {
            List<Policy> policyU = GetPolicyByInsurance(policy.insurance);
            Policy thisPolicy = GetPolicyByID(policy.policyID);
            return _repo.UpdatePolicy(policy);
        }
        catch (InvalidUserException)
        {
            throw new InvalidUserException();
        }
        catch (PolicyNotAvailable)
        {
            throw new PolicyNotAvailable();
        }
    }
    /// <summary>
    /// will delete a policy
    /// </summary>
    /// <param name="policyID">Active policyID</param>
    /// <returns>deleted polcy</returns>
    /// <exception cref="NotImplementedException">That policy is not exist</exception>
     public Policy DeletePolicy(int policyID)
    {
       // return _repo.DeletePolicy(policyID) ?? throw new NotImplementedException();
       try
        {
            List<Policy> all = GetAllPolicy();
            foreach(Policy policy in all)
            {
                if(policy.policyID == policyID)
                {
                    return _repo.DeletePolicy(policyID);
                }
            }
            throw new PolicyNotAvailable();
        }
        catch (PolicyNotAvailable)
        {
            throw new PolicyNotAvailable();
        }
    }
}