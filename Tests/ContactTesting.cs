using Moq;
using NewModels;
using Services;
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

        //Verifying that the returned result is the same as what we've sent as well as what we've had the mock repository to respond with
        Assert.NotNull(returnedContactInfo);
        Assert.Equal(returnedContactInfo.contactID, contactToReturn.contactID);
        Assert.Equal(returnedContactInfo.email, contactToAdd.email);
    }
}