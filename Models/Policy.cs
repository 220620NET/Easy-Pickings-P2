
namespace Models
{
    public class Policy
    {
        public int policyID { get; set; }
        public int insurance { get; set; }
        public FileStream? coverage { get; set; }

        public Policy()
        {
             coverage = null;
             policyID = 0;
             insurance = 0;
        }
        // Used for creating a policy
        public Policy(FileStream coverage, int insurance)
        {
            this.coverage = coverage;
            this.insurance = insurance;
        }
        // Used for getting all policies
        public Policy(int policyID, int insurance,FileStream coverage)
        {
            this.policyID = policyID;
            this.insurance = insurance;
            this.coverage = coverage;
        }
    }
}
