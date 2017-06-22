using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excavator.Models;

namespace Excavator
{
    public class Digger
    {
        public async void Start(string startPoint)
        {
            await method("http://shiep.edu.cn");
            while (nxList.Count != 0)
            {
                await method(nxList.Dequeue());
            }   
        }

        public async Task<string> method(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                var rActionLink = new Regex(@"<a.*href=""\S*""");
                var rLink = new Regex(@"href=""\S*""");
                var rTitle = new Regex(@"<title>\S*</title>");
                var actionLink = rActionLink.Matches(content);
                var title = rTitle.Match(content).Value;
                if (title.Length != 0)
                    title = title.Substring(7, title.Length - 15);

                foreach (Match item in actionLink)
                {
                    var link = rLink.Match(item.Value).Value;
                    link = link.Substring(6, link.Length - 7);
                    if (link.StartsWith("http"))
                    {
                        if (!nxList.Contains(link))
                            nxList.Enqueue(link);
                    }
                    else if (link.StartsWith("/") || link.StartsWith("~"))
                    { }
                    else
                    { }
                }

                return title;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error, {0}", e);
            }

            return "1";
        }

        public void Stop()
        {
            nxList.Clear();
        }

        public Queue<string> nxList = new Queue<string>();
    
        private readonly appContext _context;

        public Digger(appContext context)
        {
            _context = context;
        }
    }
}
