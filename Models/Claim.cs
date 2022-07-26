using System.ComponentModel.DataAnnotations;

namespace Models
{
    public enum Status
    {
        Pending,Approved,Denied
    }
    public class Claim
    {
        [Key]
        public int claimID { get; set; }
        public int userID { get; set; }
        public int doctorID { get; set; }
        public int policyID {get; set; }
        public FileStream? reasonForVisit { get; set; }
        public Status status { get; set; }
        public Claim()
        {
            claimID = 0;
            userID = 0;
            doctorID = 0;
            policyID = 0;
            reasonForVisit = null;
            status = Status.Pending;
        }
        //For Making a claim
        public Claim( int userIDFK, int doctorIDFK, int providerIDFK, FileStream reasonForVisit ):this()
        { 
            this.userID = userIDFK;
            this.doctorID= doctorIDFK;
            this.policyID = providerIDFK;
            this.reasonForVisit = reasonForVisit; 
        }
        public Claim(int claimID, int userIDFK, int doctorIDFK, int providerIDFK, FileStream? reasonForVisit, Status status)
        {
            this.claimID = claimID;
            this.userID = userIDFK;
            this.doctorID = doctorIDFK;
            this.policyID = providerIDFK;
            this.reasonForVisit = reasonForVisit;
            this.status = status;
        }
    }
}
