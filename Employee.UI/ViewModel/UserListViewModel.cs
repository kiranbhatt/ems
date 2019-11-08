using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.UI.ViewModel
{
    public class UserListViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        public long AadhaarNumber { get; set; }
        public string PanCardNumber { get; set; }
        public bool IsActive { get; set; }
    }
}