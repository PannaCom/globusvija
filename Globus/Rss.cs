using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using System.IO;

namespace Globus
{
    public class Rss
    {
        public struct ItemXml
        {
            //public long id;//id của tin đó
            public string title;//Tên của tin tức
            public string link;//link của tin
            public string description;//tóm tắt tin           
            public string image;//ảnh của tin
        }
        public ItemXml[] arrItem = null;
        public int Length = 0;
        public Rss(string url)
        {
            Length = 0;            
            arrItem = new ItemXml[200];
            getAllItem(url);            
        }
        public ItemXml[] getRssItem() {
            return arrItem;
        }

        //Doc Rss
        private void getAllItem(string Url)
        {
            //if (Url.Contains("google.com")) {
            //    int abc = 0;
            //}
            string nowDate = DateTime.Now.ToString();
            //Fetch the subscribed RSS Feed
            XmlDocument RSSXml = new XmlDocument();
            

            try
            {
                RSSXml.Load(Url);
            }
            catch (Exception ex)
            {
                return;
            }
            //if (Url.Contains("doisongphapluat")) {
            //    int abc = 0;
            //}
            XmlNodeList RSSNodeList = RSSXml.SelectNodes("rss/channel/item");
            XmlNode RSSDesc = RSSXml.SelectSingleNode("rss/channel/title");

            StringBuilder sb = new StringBuilder();

            foreach (XmlNode RSSNode in RSSNodeList)
            {
                XmlNode RSSSubNode;
                RSSSubNode = RSSNode.SelectSingleNode("title");
                string title = RSSSubNode != null ? RSSSubNode.InnerText : "";

                RSSSubNode = RSSNode.SelectSingleNode("link");
                string link = RSSSubNode != null ? RSSSubNode.InnerText : "";
                

                RSSSubNode = RSSNode.SelectSingleNode("description");
                string description = RSSSubNode != null ? RSSSubNode.InnerText : "";

                


                if (title != null && title != "")
                {
                    link = link.Trim();
                    title = title.Trim();
                    
                    arrItem[Length].title = title.Trim();
                    arrItem[Length].link = link.Trim();
                    arrItem[Length].description = description;
                    
                    Length++;
                }
            }
            Array.Resize(ref arrItem, Length);
        }//void
        
    }
}