using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPolicy
    {
       public List<Policy> GetPolicyByPolicyID(int policyID);
       public List<Policy> GetAllPolicy();
       public List<Policy> GetPolicyByuserID(int insurance);
      public List<Policy> GetPolicyBycoverage(FileStream coverage);
    }
}
