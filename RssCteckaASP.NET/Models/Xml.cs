using System.Xml.Serialization;

namespace RssCteckaASP.NET.Models
{
    public class Xml
    {
        public Rss rss { get; set; }
    }
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel channel { get; set; }
    }
    public class Channel
    {
        [XmlElement("item")]
        public List<Item> item { get; set; }
    }
    public class Item
    {
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("description")]
        public string description { get; set; }
        [XmlElement("pubDate")]
        public string pubDate { get; set; }
    }
}
