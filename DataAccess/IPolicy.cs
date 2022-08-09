using NewModels;


namespace DataAccess
{
    public interface IPolicy
    {
       public Policy GetPolicyByID(int policyID);
       public List<Policy> GetAllPolicy();
       public List<Policy> GetPolicyByInsurance(int insurance);
        public List<Policy> GetPolicyBycoverage(string coverage);
        public Policy UpdatePolicy(Policy policy);
        public Policy DeletePolicy(int ID);
        public Policy CreatePolicy(Policy policy);
    }
}
