using System.ComponentModel.DataAnnotations;
using WineLibrary;

namespace WineTest.Pages.DTO
{
    public class ContactDTO
    {
        public ContactDTO() { }

        public ContactDTO(Contacts contact) 
        {
            Email = contact.Email;
            Topic = contact.Topic;
            Subject = contact.Subject;
        
        }

        public string Email { get; set; }
        public string Topic { get; set; }
        public string Subject { get; set; }
    }
}
