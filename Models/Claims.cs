using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Status
    {
        Pending,Approved,Denied
    }
    public class Claims
    {
        public int claimID { get; set; }
        public int userIDFK { get; set; }
        public int doctorIDFK { get; set; }
        public int providerIDFK {get; set; }
        public FileStream? reasonForVisit { get; set; }
        public Status status { get; set; }
        public Claims()
        {
            claimID = 0;
            userIDFK = 0;
            doctorIDFK = 0;
            providerIDFK = 0;
            reasonForVisit = null;
            status = Status.Pending;
        }
        //For Making a claim
        public Claims( int userIDFK, int doctorIDFK, int providerIDFK, FileStream reasonForVisit ):this()
        { 
            this.userIDFK = userIDFK;
            this.doctorIDFK = doctorIDFK;
            this.providerIDFK = providerIDFK;
            this.reasonForVisit = reasonForVisit; 
        }
        public Claims(int claimID, int userIDFK, int doctorIDFK, int providerIDFK, FileStream? reasonForVisit, Status status)
        {
            this.claimID = claimID;
            this.userIDFK = userIDFK;
            this.doctorIDFK = doctorIDFK;
            this.providerIDFK = providerIDFK;
            this.reasonForVisit = reasonForVisit;
            this.status = status;
        }
    }
}
