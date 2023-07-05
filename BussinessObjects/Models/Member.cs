using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Member
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		[DisplayName("Avatar")]
		public string LinkAvatar { get; set; }
		public bool Gender { get; set; }
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime? BirthDate { get; set; }
		public int? ParentId { get; set; }
		public string AccountId { get; set; }
		public int? FamilyId { get; set; }
		public virtual Account Account { get; set; }
		public virtual Family Family { get; set; }
		public virtual Family FamilyCreated { get; set; }
		public virtual Couple Parent { get; set; }
		public virtual ICollection<Couple> CouplesFather { get; set; }
		public virtual ICollection<Couple> CouplesMother { get; set; }
		public virtual ICollection<EventAttendees> EventAttendees { get; set; }

	}
}
