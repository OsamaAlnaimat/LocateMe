using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
	public class Map : GenrateGuid
	{	
		public string PlaceName { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public  int Count { get; set; } = 0; 
	}
}
