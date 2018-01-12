using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesforceTwitter.Twitter;
using SalesforceTwitter.Models;

namespace SalesforceTwitter.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			TwitterReader objTwitter = new TwitterReader
			{
				OAuthConsumerKey = "kiVWzXFJJj4ZdblXDMwFxuWxI",
				OAuthConsumerSecret = "7QZL2HLcSH2nJYD6D7iLGcxlPmeP0wAYYAJdopUr2Lx3SzAUZx"
			};
		
			
			return View(objTwitter.GetLatestTweets());
		}

		
	}
}