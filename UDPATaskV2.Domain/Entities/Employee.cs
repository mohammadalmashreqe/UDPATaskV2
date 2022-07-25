using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Domain.Common;

namespace UDPATaskV2.Domain.Entities
{
    public class Employee : BaseDomainEntity
    {
        [Column(TypeName = "nvarchar (150)")]
        public string Name { get; set; }
        public Guid DepartmentId { set; get; }
        public DateTime JoiningDate { set; get; }
        public DateTime DateofBirth { set; get; }

        [Column(TypeName = "Ntext")]

        public string Address { get; set; }
        [Column(TypeName = "Nvarchar(100)")]

        public string ImageUrl { get; set; }
        public Guid UserId { get; set; }

        public virtual Departments Department { get; set; }


    }
}