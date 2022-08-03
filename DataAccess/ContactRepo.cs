using NewModels;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.contact.Add(contact);
            Finish();
            return contact ?? throw new NotImplementedException();
        }
        //probably don't need

        public Contact DeleteContactInfo(int contactID)
        {
            Contact contactToDelete =_dbContext.contact.FirstOrDefault(contact=>contact.contactID==contactID)??throw new NotImplementedException();
            _dbContext.contact.Remove(contactToDelete);
            Finish();
            return contactToDelete ?? throw new NotImplementedException();
        }
        public List<Contact> GetAllContactInfo()
        {

            return _dbContext.contact.ToList();

        }

        public Contact GetContactInfoByEmail(string email)
        {

            Contact? contact = _dbContext.contact.FirstOrDefault(contact => contact.email == email);

            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoById(int contactID)
        {

            Contact? contact = _dbContext.contact.FirstOrDefault(contact => contact.contactID == contactID);

            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoByPhone(int phone)
        {

            Contact? contact = _dbContext.contact.FirstOrDefault(contact => contact.phone == phone);

            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact UpdateContactInfo(Contact contact)
        {

            _dbContext.contact.Update(contact);
            Finish();
            return contact ?? throw new NotImplementedException();
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
