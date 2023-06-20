using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Family
	{
		public int Id { get; set; }
		public int CreatorId { get; set; }
		public virtual Member Creator { get; set; }
		public virtual ICollection<Image> Images { get; set; }
		public virtual ICollection<Member> Members { get; set; }
		public virtual ICollection<Event> Events { get; set; }

	}
}
