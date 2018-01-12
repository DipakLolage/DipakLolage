using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesforceTwitter.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;

namespace SalesforceTwitter.Twitter
{
	public class TwitterReader
	{
		public string OAuthConsumerSecret { get; set; }
		public string OAuthConsumerKey { get; set; }

		public async Task<List<Tweets>> GetTwitts(string userName, int count, string accessToken = null)
		{
			if (accessToken == null)
			{
				accessToken = await GetAccessToken().ConfigureAwait(false);
			}

			var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get,
			string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count={1}", userName, count));


			requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
			var httpClient = new HttpClient();
			HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline).ConfigureAwait(false);
			var serializer = new JavaScriptSerializer();
			List<Tweets> json = serializer.Deserialize<List<Tweets>>(await responseUserTimeLine.Content.ReadAsStringAsync());
		
			if (json == null)
			{
				return null;
			}
			return json;
		}

		public async Task<string> GetAccessToken()
		{
			var httpClient = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token");
			var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
			request.Headers.Add("Authorization", "Basic " + customerInfo);
			request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

			HttpResponseMessage response = await httpClient.SendAsync(request).ConfigureAwait(false);

			string json = await response.Content.ReadAsStringAsync();
			var serializer = new JavaScriptSerializer();
			dynamic item = serializer.Deserialize<object>(json);
			return item["access_token"];
		}

		public List<TweetsItem> GetLatestTweets()
		{
			List<TweetsItem> lstTweetsList = new List<TweetsItem>();
			TweetsItem objTweetsItem;
			List<Tweets> lstTwitts = GetTwitts("salesforce", 10).Result;

			foreach (Tweets objTweet in lstTwitts)
			{
				objTweetsItem = new TweetsItem();
				objTweetsItem.UserName = objTweet.user.name;
				objTweetsItem.ScreenName = objTweet.user.screen_name;
				objTweetsItem.Text = objTweet.GetTextWithLinks();
				objTweetsItem.FavoriteCount = objTweet.favorite_count;				
				objTweetsItem.RetweetCount = objTweet.retweet_count;
				if (objTweet.entities != null)
				{
					if (objTweet.entities.media != null)
					{
						foreach (Media objMedia in objTweet.entities.media)
							objTweetsItem.TweetImage = objMedia.media_url;
					}
				}
				objTweetsItem.UserImageUrl = objTweet.user.profile_image_url;
				objTweetsItem.TweetDate = "";

				lstTweetsList.Add(objTweetsItem);

			}

			return lstTweetsList;
		}
	}
}