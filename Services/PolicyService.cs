using DataAccess;
using DataAccess.Entities;

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
}