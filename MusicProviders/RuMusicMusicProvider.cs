using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.XPath;
using System.Linq;
using HtmlAgilityPack;

namespace MusicProviders
{
    public class RuMusicMusicProvider : MusicProvider
    {
        WebClient WebClient = new WebClient();
        public override IEnumerable<Song> GetSongs(string name, int count)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            name= name.Replace(" ", "%20");


            var doc = htmlWeb.Load("https://ru-music.com/search/" + name + "/");
            foreach (var songLi in doc.DocumentNode.SelectNodes("//li[@class=\"track\"]"))
            {
               var imagePath=songLi.GetAttributeValue("data-img", "http://icons.iconarchive.com/icons/martz90/circle/256/music-icon.png");
            };
         



            return null;
        }

    }
}
