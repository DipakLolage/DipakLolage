using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesforceTwitter.Models
{
	public class Tweets
	{
		
		public string created_at { get; set; }
		public string text { get; set; }
		public string retweet_count { get; set; }
		public string GetTextWithLinks()
		{
			var result = text;

			
				foreach (var url in entities.urls)
				{
					result = result.Replace(
					  url.url,
					  string.Format("<a href='{0}'>{1}</a>",
						url.expanded_url,
						url.display_url));
				}
			

			return result;
		}
		public User user { get; set; }
		public Entity entities { get; set; }
		public string source { get; set; }
		public string favorite_count { get; set; }
		public string time_zone { get; set; }
	}	
}