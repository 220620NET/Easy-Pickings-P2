using NewModels;


namespace DataAccess
{
    public interface IPolicy
    {
        Policy GetPolicyByID(int policyID);
        List<Policy> GetAllPolicy();
        List<Policy> GetPolicyByInsurance(int insurance);
        List<Policy> GetPolicyBycoverage(string coverage);
        Policy UpdatePolicy(Policy policy);
        bool DeletePolicy(int ID);
        Policy CreatePolicy(Policy policy);
    }
}
