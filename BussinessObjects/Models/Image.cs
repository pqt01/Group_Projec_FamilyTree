using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
	public class Image
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public int FamilyId { get; set; }
		public virtual Family Family { get; set; }
	}
}
