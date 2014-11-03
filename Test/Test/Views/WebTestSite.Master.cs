using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.Mvc.Html;

namespace Test
{
    public partial class WebTestSite : System.Web.Mvc.ViewMasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://api.vk.com/method/photos.get?owner_id=-77494107&album_id=profile&v=5.24");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader myStream = new StreamReader(stream);
            string JSONString = "";
            for (string line = myStream.ReadLine(); line != null; line = myStream.ReadLine())
            {
                JSONString += line;
            }

            var obj = JsonConvert.DeserializeObject<dynamic>(JSONString);
            int count = obj.response.count;
            logoIm.ImageUrl = obj.response.items[count - 1].photo_130;
        }

        
    
    }
}