using Moq;
using NewModels;
using Services;
using CustomExceptions;
using DataAccess;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Tests;
    
public class ContactTesting
{
    [Fact]
    public void CreateContactWithValidInfo()
    {
        var mockedRepo = new Mock<IContactRepo>();
        Contact contactToAdd = new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        };

        Contact contactToReturn = new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        };

        mockedRepo.Setup(repo => repo.CreateContactInfo(contactToAdd)).Returns(contactToReturn);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Contact returnedContactInfo = contactService.CreateContactInfo(contactToAdd);

        //Assert (Verification)
        mockedRepo.Verify(repo => repo.CreateContactInfo(contactToAdd), Times.Once());

        //Verifying that the returned result is the same as what
        //we've sent as well as what we've had the mock repository to respond with

        Assert.NotNull(returnedContactInfo);
        Assert.Equal(returnedContactInfo.contactID, contactToReturn.contactID);
        Assert.Equal(returnedContactInfo.email, contactToAdd.email);
    }

    [Fact]
    public void DeleteContactInfoFailsWithInvalidID()
    {
        var mockedRepo = new Mock<IContactRepo>();

        List<Contact> contacts = new();

        contacts.Add(new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        });

        Contact contact = new()
        {
            contactID = 2,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        };

        mockedRepo.Setup(repo => repo.GetAllContactInfo()).Returns(contacts);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Assert.Throws<ContactNotAvailableException>(() => contactService.DeleteContactInfo(contact.contactID));
    }

    [Fact]
    public void UpdateContactInfoFailsWithInvalidID()
    {
        var mockedRepo = new Mock<IContactRepo>();

        List<Contact> contacts = new();

        contacts.Add(new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        });

        Contact contact = new()
        {
            contactID = 2,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 93894,
            userID = 4,
            phone = 6505567890,
            email = "someone@somewhere.com"
        };

        mockedRepo.Setup(repo => repo.GetAllContactInfo()).Returns(contacts);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Assert.Throws<ContactNotAvailableException>(() => contactService.UpdateContactInfo(contact));
    }

     [Fact]
    public void GetContactInfoFailsWithInvalidID()
    {
        var mockedRepo = new Mock<IContactRepo>();

        List<Contact> contacts = new();

        contacts.Add(new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        });

        int contactID = 2;

        mockedRepo.Setup(repo => repo.GetAllContactInfo()).Returns(contacts);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Assert.Throws<ContactNotAvailableException>(() => contactService.GetContactInfoById(contactID));
    }

     [Fact]
    public void GetContactInfoFailsWithInvalidEmail()
    {
        var mockedRepo = new Mock<IContactRepo>();

        List<Contact> contacts = new();

        contacts.Add(new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        });

        string email = "something@someplace.org";

        mockedRepo.Setup(repo => repo.GetAllContactInfo()).Returns(contacts);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Assert.Throws<ContactNotAvailableException>(() => contactService.GetContactInfoByEmail(email));
    }

    [Fact]
    public void GetContactInfoFailsWithInvalidPhone()
    {
        var mockedRepo = new Mock<IContactRepo>();

        List<Contact> contacts = new();

        contacts.Add(new()
        {
            contactID = 1,
            PO_or_street = false,
            PO_number = 0,
            street_number = 1900,
            street_name = "Main Street",
            city_state = "San Francisco, CA",
            zipcode = 97894,
            userID = 4,
            phone = 6505557890,
            email = "someone@somewhere.com"
        });

        long phonenum = 4086504444;

        mockedRepo.Setup(repo => repo.GetAllContactInfo()).Returns(contacts);

        ContactService contactService = new (mockedRepo.Object);

        //Act
        Assert.Throws<ContactNotAvailableException>(() => contactService.GetContactInfoByPhone(phonenum));
    }
}
