using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;

namespace DataAccess;


public interface IContactRepo
{
    public List<Contact> GetAllContactInfo();  
    public Contact CreateContactInfo(Contact contact);
    public Contact UpdateContactInfo(Contact contact);
    public bool DeleteContactInfo(int contactID);
    public Contact GetContactInfoById(int contactID);
    public Contact GetContactInfoByUserId(int userID);
    public Contact GetContactInfoByEmail(string email);
    public Contact GetContactInfoByPhone(long phone);
}