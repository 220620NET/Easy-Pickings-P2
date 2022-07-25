

namespace Models
{
    public class Contact
    {
        public int contactId { get; set; }
        public bool POorStreet { get; set; }
        public int PONumber { get; set; }
        public int streetNumber { get; set; }
        public string streetName { get; set; }
        public string cityState { get; set; }
        public int zipcode { get; set; }
        public int phone { get; set; }
        public string email { get; set; }

        //For reading from Json
        public Contact()
        {
            contactId = 0;
            PONumber = 0;
            streetNumber = 0;
            POorStreet = false;
            streetName = "";
            cityState = "";
            zipcode = 0;
            phone = 0;
            email = "";
        }

        //For creating a new contact
        public Contact(int contactId,bool POorStreet, int PONumber,  int streetNumber, string streetName, string cityState, int zipcode, int phone, string email)
        {
            this.contactId = contactId;
            this.POorStreet = POorStreet;
            this.PONumber = PONumber;
            this.streetNumber = streetNumber;
            this.email = email;
            this.streetName = streetName;
            this.cityState = cityState;
            this.zipcode = zipcode;
            this.phone = phone;
        }
    }
}
