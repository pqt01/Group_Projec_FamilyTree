using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class EventAttendees
	{
		public int Id { get; set; }
		public int MemberId { get; set; }
		public int EventId { get; set; }
		public virtual Event Event { get; set; }
		public virtual Member Member { get; set; }
		
	}
}
