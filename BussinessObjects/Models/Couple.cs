using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Couple
	{
		public int Id { get; set; }
		public int? FaId { get; set; }
		public int? MoId { get; set; }
		public virtual Member Father { get; set; }
		public virtual Member Mother { get; set; }
		public virtual ICollection<Member> Childs { get; set; }

	}
}
