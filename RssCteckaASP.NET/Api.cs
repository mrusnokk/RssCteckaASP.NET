namespace RssCteckaASP.NET
{
    using Models;
    using System.Xml.Serialization;

    public class Api
    {
        

        public async Task<Rss> getXml(string url) {
            using (HttpClient cl = new HttpClient()){ 
                HttpResponseMessage res = await cl.GetAsync(url);
                if (!res.IsSuccessStatusCode) {
                    return null;
                }
                string xml = await res.Content.ReadAsStringAsync();
                if (xml == null) {
                    return null;
                }
                
               try{ using (StringReader s = new StringReader(xml))
                    {
                        XmlSerializer x = new XmlSerializer(typeof(Rss));
                        return (Rss)x.Deserialize(s);
                    }
                }
                catch { }
                return null;
            }
        }

    }
}
