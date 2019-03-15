using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamTeamProject
{
    public static class People
    {
        public static List<User> Users = new List<User>() {
            new User { Id = 0, FirstName = "Mike", SecondName = "Ross", Mail = "mike@tmail.com", Phone = "+234235", Password = "123", ConfirmedPassword = "123" },
            new User { Id = 1, FirstName = "Jane", SecondName = "Doe", Mail = "jane@hjmail.com", Phone = "+894567", Password = "456", ConfirmedPassword = "456" },
            new User { Id = 2, FirstName = "John", SecondName = "Doe", Mail = "john@etmail.com", Phone = "+174797", Password = "789", ConfirmedPassword = "789" },
        };
    }
}
