using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewModels;

namespace DataAccess;


public interface IContactRepo
{
    List<Contact> GetAllContactInfo();  
    Contact CreateContactInfo(Contact contact);
    Contact UpdateContactInfo(Contact contact);
    bool DeleteContactInfo(int contactID);
    Contact GetContactInfoById(int contactID);
    Contact GetContactInfoByUserId(int userID);
    Contact GetContactInfoByEmail(string email);
    Contact GetContactInfoByPhone(long phone);
}