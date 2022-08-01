using CustomExceptions;
using NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ContactRepo : IContactRepo
    {
        private readonly InsuranceDbContext _context;

        public ContactRepo(InsuranceDbContext context)
        {
            _context = context;
        }

        public Contact CreateContactInfo(Contact contact)
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }
        //probably don't need
        public List<Contact> GetAllContactInfo()
        {
            return _context.contacts.ToList();
        }

        public Contact GetContactInfoByEmail(string email)
        {
            Contact? contact = _context.contacts.FirstOrDefault(contact => contact.email == email);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoById(int contactID)
        {
            Contact? contact = _context.contacts.FirstOrDefault(contact => contact.contactID == contactID);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoByPhone(int phone)
        {
            Contact? contact = _context.contacts.FirstOrDefault(contact => contact.phone == phone);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact UpdateContactInfo(Contact contact)
        {
            _context.contacts.Update(contact);
            _context.SaveChanges();
            return contact;
            throw new NotImplementedException();
        }
    }
}
