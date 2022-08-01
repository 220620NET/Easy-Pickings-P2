using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using NewModels;


namespace Services
{
    public class ContactService
    {
        private readonly IContactRepo _contact;
        public ContactService(IContactRepo contact)
        {
            _contact = contact;
        }
        public List<Contact> GetAllContactInfo()
        {
            return _contact.GetAllContactInfo();
            throw new NotImplementedException();
        }
        public Contact CreateContactInfo(Contact contact)
        {
            return _contact.CreateContactInfo(contact);
            throw new NotImplementedException();
        }
        public Contact UpdateContactInfo(Contact contact)
        {
            return _contact.UpdateContactInfo(contact);
            throw new NotImplementedException();
        }
        public Contact GetContactInfoById(int contactID)
        {
            return _contact.GetContactInfoById(contactID);
            throw new NotImplementedException();
        }
        public Contact GetContactInfoByEmail(string email)
        {
            return _contact.GetContactInfoByEmail(email);
            throw new NotImplementedException();
        }
        public Contact GetContactInfoByPhone(int phone)
        {
            return _contact.GetContactInfoByPhone(phone);
            throw new NotImplementedException();
        }

    }
}
