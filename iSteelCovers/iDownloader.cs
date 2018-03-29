using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iSteelCovers
{
    class iDownloader
    {
        public static JObject JsonData(string iUrl)
        {
            JObject Results = new JObject();
            var webRequest = WebRequest.Create(iUrl);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                Results = JObject.Parse(strContent);
            }
            return Results;
        }

        public static string GetArtistPreview(string ArtistUrl)
        {
            string ArtistImageLink = "";
            var webRequest = WebRequest.Create(ArtistUrl);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                //Debug.WriteLine(strContent);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(strContent);

                var links = htmlDoc.DocumentNode.Descendants("meta");
                var Count = 0;
                foreach (var link in links)
                {
                    Debug.WriteLine(Count);
                    Count++;
                    if (link.Attributes["name"] != null && link.Attributes["name"].Value == "twitter:image")
                    {
                        string FileName = Path.GetFileName(link.Attributes["content"].Value);
                        ArtistImageLink = link.Attributes["content"].Value.Replace(FileName,"250x250.jpg");
                        break;
                    }
                }
                return ArtistImageLink;
            }
        }
    }
}
