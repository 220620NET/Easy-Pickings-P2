using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess;


public interface IContactRepo
{
    public List<Contact> GetAllContactInfo(); //probably not needed
    public Contact CreateContactInfo(Contact contact);
    public Contact UpdateContactInfo(Contact contact);
    public Contact GetContactInfoById(int contactID);
    public Contact GetContactInfoByEmail(string email);
    public Contact GetContactInfoByPhone(int phone);
}
