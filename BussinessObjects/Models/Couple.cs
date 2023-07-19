using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Mate
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public virtual Mate Parent { get; set; }
		public virtual ICollection<Mate> Children { get; set; }
		public virtual ICollection<Member> Members { get; set; }

	}
}
