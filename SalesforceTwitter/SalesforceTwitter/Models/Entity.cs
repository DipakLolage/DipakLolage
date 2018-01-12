using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesforceTwitter.Models
{
	public class Entity
	{
		public List<Url> urls { get; set; }
		public List<Media> media { get; set; }
	}
}