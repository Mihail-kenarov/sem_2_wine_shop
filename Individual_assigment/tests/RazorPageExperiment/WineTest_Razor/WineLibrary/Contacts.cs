using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineLibrary
{
    public class Contacts
    {
        private string email;
        private string topic;
        private string subject;

        public Contacts() { }


        public Contacts(string email, string topic, string subject)
        {
        this.email = email;
        this.topic = topic;
        this.subject = subject;
        }


        public string Email { get => email; }
        public string Topic { get => topic; }  
        public string Subject { get => subject; }






    }
}
