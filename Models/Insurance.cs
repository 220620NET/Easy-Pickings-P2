
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Insurance
    {
        
        public int policyID { get; set; }
        public int userID { get; set; }

        public Insurance()
        {
             policyID = 0;
             userID= 0;
             
        }
        // Used for creating and getting a new insurace class
        public Insurance(int provider, int benefactor)
        {
            this.policyID = provider;
            this.userID = benefactor;
        } 
    }
}
