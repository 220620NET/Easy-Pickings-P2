using DataAccess;
using NewModels;

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
        return _repo.GetPolicyByID(policyID)?? throw new NotImplementedException();
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
        return _repo.GetPolicyByInsurance(insurance)?? throw new NotImplementedException();
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
        return _repo.CreatePolicy(policy) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// wiil update a policy
    /// </summary>
    /// <param name="policy">Active policy that needs to update</param>
    /// <returns>updated policy</returns>
    /// <exception cref="NotImplementedException">That policy could not be updated</exception>
    public Policy UpdatePolicy(Policy policy)
    {
        return _repo.UpdatePolicy(policy) ?? throw new NotImplementedException();
    }
    /// <summary>
    /// will delete a policy
    /// </summary>
    /// <param name="policyID">Active policyID</param>
    /// <returns>deleted polcy</returns>
    /// <exception cref="NotImplementedException">That policy is not exist</exception>
     public Policy DeletePolicy(int policyID)
    {
        return _repo.DeletePolicy(policyID) ?? throw new NotImplementedException();
    }
}