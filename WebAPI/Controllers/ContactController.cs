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

    public IResult CreateContactInfo(Contact contact)
    {
        try
        {
            return Results.Accepted("/submit/contact", _service.CreateContactInfo(contact));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }

    public IResult UpdateContactInfo(Contact contact)
    { 
        try
        {
            return Results.Accepted("/contact/ID/{contactID}", _service.UpdateContactInfo(contact));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
    }

    public IResult DeleteContactInfo(int contactID)
    { 
        try
        {
            return Results.Accepted("/delete/contact/{contactID}", _service.DeleteContactInfo(contactID));
        }
        catch (NotImplementedException)
        {
            return Results.BadRequest();
        }
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
    public IResult GetContactInfoByUserId(int userID)
    {
        try
        {
            return Results.Accepted("/contact/user/{userID}", _service.GetContactInfoByUserId(userID));
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

