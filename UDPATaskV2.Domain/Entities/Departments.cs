using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Domain.Common;

namespace UDPATaskV2.Domain.Entities
{
    public class Departments : BaseDomainEntity
    {
        [Column(TypeName = "nvarchar (100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar (5)")]
        public string Code { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
