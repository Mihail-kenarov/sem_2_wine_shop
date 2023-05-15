using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ContactFeedback
    {
        public ContactFeedback() { }

        public ContactFeedback(string name,string email,string subject) 
        {
            Name = name;
            Email = email;
            Subject = subject;
        }

		[Required]
		public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Range(5,250)]
        public string Subject { get; set; }








    }
}
