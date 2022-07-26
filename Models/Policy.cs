
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Policy
    {
        [Key]
        public int policyID { get; set; }
        public int userID { get; set; }
        public FileStream? coverage { get; set; }

        public Policy()
        {
             coverage = null;
             policyID = 0;
             userID = 0;
        }
        // Used for creating a policy
        public Policy(FileStream coverage, int insurance)
        {
            this.coverage = coverage;
            this.userID = insurance;
        }
        // Used for getting all policies
        public Policy(int policyID, int insurance,FileStream coverage)
        {
            this.policyID = policyID;
            this.userID = insurance;
            this.coverage = coverage;
        }
    }
}
