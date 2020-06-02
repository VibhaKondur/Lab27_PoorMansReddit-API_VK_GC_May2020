using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AspNetCore;

namespace Lab27_PoorMansReddit.Models
{
    public class RedditDAL
    {
        //API calls break most commonly in 2 spots:
        //1. Setting up the request - url
        //2. Deserialization/serialization 
        public string GetAPIString(string subreddit)
        {
            string url = $"https://www.reddit.com/r/{subreddit}/.json";

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();
            return output;
        }

        public RedditPost GetPost()
        {
            string output = GetAPIString("aww");

            //special collection used with Json data
            //useful when you have an API with an enormous amount of data
            JObject json = JObject.Parse(output);

            List<JToken> modelData = json["data"]["children"].ToList();
            string s = modelData[0]["data"].ToString();

            RedditPost rp = JsonConvert.DeserializeObject<RedditPost>(modelData[0]["data"].ToString());
            return rp;
        }




    }
}
