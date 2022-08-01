using DataAccess;
using NewModels;

namespace Services;

public class PolicyService
{
    private readonly IPolicy _repo;
    public PolicyService(IPolicy repo)
    {
        _repo = repo;
    }
    public List<Policy> GetPolicyByID(int policyID)
    {
        return _repo.GetPolicyByID(policyID);
    }
     public List<Policy> GetAllPolicy()
    {
        return _repo.GetAllPolicy();
    }
    public List<Policy> GetPolicyByInsurance(int insurance)
    {
        return _repo.GetPolicyByInsurance(insurance);
    }

    public List<Policy> GetPolicyBycoverage(string coverage)
    {
        return _repo.GetPolicyBycoverage(coverage);
    }
     public Policy CreatePolicy(Policy policy)
    {
        return _repo.CreatePolicy(policy) ?? throw new NotImplementedException();
    }
    public Policy UpdatePolicy(Policy policy)
    {
        return _repo.UpdatePolicy(policy) ?? throw new NotImplementedException();
    }
     public Policy DeletePolicy(int policyID)
    {
        return _repo.DeletePolicy(policyID) ?? throw new NotImplementedException();
    }
}