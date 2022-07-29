using CustomExceptions;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ContactRepo : IContactRepo
    {
        private readonly easypickingsContext _context;

        public ContactRepo(easypickingsContext context)
        {
            _context = context;
        }

        public Contact CreateContactInfo(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }
        //probably don't need
        public List<Contact> GetAllContactInfo()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetContactInfoByEmail(string email)
        {
            Contact? contact = _context.Contacts.FirstOrDefault(contact => contact.Email == email);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoById(int contactID)
        {
            Contact? contact = _context.Contacts.FirstOrDefault(contact => contact.ContactId == contactID);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact GetContactInfoByPhone(int phone)
        {
            Contact? contact = _context.Contacts.FirstOrDefault(contact => contact.Phone == phone);
            if (contact != null) return contact;
            throw new NotImplementedException();
        }

        public Contact UpdateContactInfo(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return contact;
            throw new NotImplementedException();
        }
    }
}
