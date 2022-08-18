using DataAccess;
using NewModels;
using CustomExceptions;


namespace Services
{
    public class ContactService
    {
        private readonly IContactRepo _contactRepo;
        public ContactService(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }
        public List<Contact> GetAllContactInfo()
        {
            return _contactRepo.GetAllContactInfo() ?? throw new ContactNotAvailableException();
        }
        public Contact CreateContactInfo(Contact contact)
        {
            return _contactRepo.CreateContactInfo(contact) ?? throw new ContactNotAvailableException();
        }
        public Contact DeleteContactInfo(int contactID)
        {
            try {
                bool found = false;
                List<Contact> allContacts = _contactRepo.GetAllContactInfo();

                foreach (Contact contact in allContacts)
                {
                    if (contact.contactID == contactID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new ContactNotAvailableException();
                Contact contactToDelete = _contactRepo.GetContactInfoById(contactID);
                _contactRepo.DeleteContactInfo(contactID);
                return contactToDelete;
            }
            catch (ContactNotAvailableException)
            {
                throw new ContactNotAvailableException();
            }
        }
        public Contact UpdateContactInfo(Contact contactToUpdate)
        {
            try {
                bool found = false;
                List<Contact> allContacts = _contactRepo.GetAllContactInfo();

                foreach (Contact contact in allContacts)
                {
                    if (contact.contactID == contactToUpdate.contactID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new ContactNotAvailableException();

                return _contactRepo.UpdateContactInfo(contactToUpdate) ?? throw new ContactNotAvailableException();
            }
            catch (ContactNotAvailableException)
            {
                throw new ContactNotAvailableException();
            }
        }
        public Contact GetContactInfoById(int contactID)
        {
            try {
                bool found = false;
                List<Contact> allContacts = _contactRepo.GetAllContactInfo();

                foreach (Contact contact in allContacts)
                {
                    if (contact.contactID == contactID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new ContactNotAvailableException();

                return _contactRepo.GetContactInfoById(contactID);
            }
            catch (ContactNotAvailableException)
            {
                throw new ContactNotAvailableException();
            }
        }
        public Contact GetContactInfoByUserId(int userID)
        {
            try
            {
                bool found = false;
                List<Contact> allContacts = _contactRepo.GetAllContactInfo();

                foreach (Contact contact in allContacts)
                {
                    if (contact.userID == userID)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new ContactNotAvailableException();

                return _contactRepo.GetContactInfoByUserId(userID);
            }
            catch (ContactNotAvailableException)
            {
                throw new ContactNotAvailableException();
            }
        }
        public Contact GetContactInfoByEmail(string email)
        {
            return _contactRepo.GetContactInfoByEmail(email) ?? throw new ContactNotAvailableException();
        }
        public Contact GetContactInfoByPhone(long phone)
        {
            return _contactRepo.GetContactInfoByPhone(phone) ?? throw new ContactNotAvailableException();
        }

    }
}
