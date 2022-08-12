﻿using NewModels;
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

        public Contact DeleteContactInfo(int contactID)
        {
            Contact contactToDelete =_dbContext.Contacts.AsNoTracking().FirstOrDefault(contact=>contact.contactID==contactID)??throw new ContactNotAvailableException();
            _dbContext.Contacts.Remove(contactToDelete);
            Finish();
            return contactToDelete;
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
            _dbContext.Contacts.Update(contact);
            Finish();
            return contact ?? throw new ContactNotAvailableException();
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
