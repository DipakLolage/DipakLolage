using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesforceTwitter.Models
{
	public class TweetsItem
	{
		public TweetsItem()
		{
			TweetImage = string.Empty;
		}
		public string UserName { get; set; }
		public string ScreenName { get; set; }
		public string UserImageUrl { get; set; }
		public string TweetImage { get; set; }
		public string RetweetCount { get; set; }
		public string FavoriteCount { get; set; }
		public string Text { get; set; }
		public string TweetDate { get; set; }
	}
}