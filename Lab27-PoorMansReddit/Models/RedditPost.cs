using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab27_PoorMansReddit.Models
{
    public class RedditPost
    {
        public string title { get; set; }
        
        //This gets us the image for the reddit post
        public string url { get; set; }

        public string permalink { get; set; }

    }
}
