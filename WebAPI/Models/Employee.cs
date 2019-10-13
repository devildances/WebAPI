using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public long _empID { get; set; }
        public long _DirectManager { get; set; }
        public long _CountryID { get; set; }
        public long _DepartmentID { get; set; }
        public long _empTADAID { get; set; }
        public string _GIN { get; set; }
        public string _Alias { get; set; }
        public string _DisplayName { get; set; }
        public string _UserPrincipalName { get; set; }
        public string _JobCode { get; set; }
        public string _MobilePhone { get; set; }
        public string _GOLDMedalOwner { get; set; }
        public float _QuestOTC { get; set; }
    }
}