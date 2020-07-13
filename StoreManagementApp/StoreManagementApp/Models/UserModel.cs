using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsManager { get; set; }
    }
}
