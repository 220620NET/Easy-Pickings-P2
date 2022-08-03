using Services;
using NewModels;
using DataAccess;

namespace WebAPI.Controllers;

public class ContactController
{
    private readonly ContactService _service;
    public ContactController(ContactService service)
    {
        _service = service;
    }
    public IResult GetAllContactInfo()
    {
        try
        {
            return Results.Accepted("/contactinfo", _service.GetAllContactInfo());
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }

   public Contact CreateContactInfo(Contact contact)
   {
       return _service.CreateContactInfo(contact);
   }

public Contact UpdateContactInfo(Contact contact)
   {
        return _service.UpdateContactInfo(contact);
   }

public Contact DeleteContactInfo(int contactID)
   {
        return _service.DeleteContactInfo(contactID);
   }

    public IResult GetContactInfoById(int contactID)
    {
        try
        {
            return Results.Accepted("/contact/ID/{contactID}", _service.GetContactInfoById(contactID));
        }
        catch (NotImplementedException)
        { 
            return Results.BadRequest();
        }
    }
    public IResult GetContactInfoByEmail(string email)
    {
        try
        {
            return Results.Accepted("/contact/email/{email}", _service.GetContactInfoByEmail(email));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }

     public IResult GetContactInfoByPhone(int phone)
    {
        try
        {
            return Results.Accepted("/contact/phone/{phone}", _service.GetContactInfoByPhone(phone));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }
}

