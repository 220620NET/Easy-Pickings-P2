using NewModels;
using Microsoft.EntityFrameworkCore;

using CustomExceptions;

namespace DataAccess
{
    public class ContactRepo : IContactRepo
    {
        private readonly InsuranceDbContext _dbContext;

        public ContactRepo(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Contact CreateContactInfo(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            Finish();
            return contact ?? throw new NotImplementedException();
        }
        //probably don't need

        public bool DeleteContactInfo(int contactID)
        {
            Contact? contactToDelete =_dbContext.Contacts.FirstOrDefault(contact=>contact.contactID==contactID);
            if(contactToDelete != null)
            {
                _dbContext.Entry(contactToDelete).State = EntityState.Deleted;
                _dbContext.SaveChanges(); 
                return true;
            }
            return false;
        }
        public List<Contact> GetAllContactInfo()
        {

            return _dbContext.Contacts.ToList();

        }

        public Contact GetContactInfoByEmail(string email)
        {

            Contact? contact = _dbContext.Contacts.AsNoTracking().FirstOrDefault(contact => contact.email == email);
            return contact?? throw new ContactNotAvailableException();
        }

        public Contact GetContactInfoById(int contactID)
        {

            Contact? contact = _dbContext.Contacts.AsNoTracking().FirstOrDefault(contact => contact.contactID == contactID);
            return contact ?? throw new ContactNotAvailableException();
        }

        public Contact GetContactInfoByPhone(long phone)
        {

            Contact? contact = _dbContext.Contacts.AsNoTracking().FirstOrDefault(contact => contact.phone == phone);
            return contact ?? throw new ContactNotAvailableException();
        }

        public Contact UpdateContactInfo(Contact contact)
        {
            try
            {
                Contact? c = _dbContext.Contacts.FirstOrDefault(t => t.contactID == contact.contactID);
                c.PO_or_street = contact.PO_or_street;
                c.PO_number = contact.PO_number!=0?contact.PO_number:c.PO_number;
                c.street_number = contact.street_number != 0 ? contact.street_number : c.street_number;
                c.street_name = contact.street_name != "" ? contact.street_name : c.street_name;
                c.city_state = contact.city_state != "" ? contact.city_state : c.city_state;
                c.zipcode = contact.zipcode != 0 ? contact.zipcode : c.zipcode;
                c.userID=contact.userID!=0?contact.userID:c.userID;
                c.phone= c.phone!=0?contact.phone:c.phone;
                c.email = contact.email!=""?contact.email:c.email;
                Finish();
                return c ?? throw new ContactNotAvailableException();

            }
            catch (ArgumentNullException)
            {
                throw new ContactNotAvailableException();
            }
        }

         /// <summary>
        /// Persist changes and clear the tracker
        /// </summary>
        protected void Finish( )
        {
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();

        }
    }
}
