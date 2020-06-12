using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukierniaEF.Models
{
	public class AddOrd
	{
		public DateTime dataPrzyjecia { get; set; }
		public string uwagi { get; set; }
		public List<WybModel> wyroby { get; set; }

	}
}
