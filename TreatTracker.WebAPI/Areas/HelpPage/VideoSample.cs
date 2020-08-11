using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreatTracker.WebAPI.Areas.HelpPage
{
    public class VideoSample
    {
   
            public VideoSample(string src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Src = src;
        }

        public string Src { get; private set; }
    }

}