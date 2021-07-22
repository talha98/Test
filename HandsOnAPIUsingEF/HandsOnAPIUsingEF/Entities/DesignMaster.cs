using System;
using System.Collections.Generic;

#nullable disable

namespace HandsOnAPIUsingEF.Entities
{
    public partial class DesignMaster
    {
        public DesignMaster()
        {
            StaffMasters = new HashSet<StaffMaster>();
        }

        public decimal DesignCode { get; set; }
        public string DesignName { get; set; }

        public virtual ICollection<StaffMaster> StaffMasters { get; set; }
    }
}
