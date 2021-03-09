using System;
using System.Collections.Generic;

namespace HRM.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<HumanResource> HumanResources { get; set; }
    }
}