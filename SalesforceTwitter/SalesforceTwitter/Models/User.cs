using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesforceTwitter.Models
{
	public class User
	{
		public string name { get; set; }
		public string profile_image_url { get; set; }
		public string screen_name { get; set; }
		public string profile_background_color { get; set; }
		public string profile_background_image_url { get; set; }
		public string profile_background_image_url_https { get; set; }
		public string profile_banner_url { get; set; }
		public string profile_link_color { get; set; }
		public string profile_sidebar_border_color { get; set; }
		public string profile_sidebar_fill_color { get; set; }
		public string profile_text_color { get; set; }
		public string url { get; set; }
	}
}