using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime OrganizeDate { get; set; }
		public int FamilyId { get; set; }
		public int ServiceId { get; set; }
		public decimal ServicePrice { get; set; }
		public int LocationId { get; set; }
		public decimal LocationPrice { get; set; }
		public virtual Family Family { get; set; }
        public virtual Service Service { get; set; }
        public virtual Location Location { get; set; }

    }
}
