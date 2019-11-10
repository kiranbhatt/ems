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
        public string AadhaarUrl { get; set; }
        public string PanUrl { get; set; }
        public bool IsActive { get; set; }
    }
}