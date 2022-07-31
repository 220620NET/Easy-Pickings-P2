using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NewModels;


namespace DataAccess
{
    public interface IPolicy
    {
       public List<Policy> GetPolicyByID(int policyID);
       public List<Policy> GetAllPolicy();
       public List<Policy> GetPolicyByInsurance(int insurance);
      public List<Policy> GetPolicyBycoverage(string coverage);
    }
}
