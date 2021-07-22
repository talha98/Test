﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HandsOnAPIUsingEF.Entities
{
    public partial class StaffMaster
    {
        public decimal StaffCode { get; set; }
        public string StaffName { get; set; }
        public decimal? DesCode { get; set; }
        public decimal? DeptCode { get; set; }
        public DateTime? StaffDob { get; set; }
        public DateTime? Hiredate { get; set; }
        public decimal? MgrCode { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
        public string MgrName { get; set; }

        public virtual DepartmentMaster DeptCodeNavigation { get; set; }
        public virtual DesignMaster DesCodeNavigation { get; set; }
    }
}
