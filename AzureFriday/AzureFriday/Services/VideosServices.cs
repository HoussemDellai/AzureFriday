using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AzureFriday.Models;

namespace MvvmFiles.Services
{
    public class EmployeesServices
    {

        /// <summary>
        /// Gets a list of all the employees.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Video>> GetVideosAsync()
        {

            var videos = new List<Video>();
            var httpClient = new HttpClient();

            var xmlResponse = await httpClient.GetStringAsync("https://channel9.msdn.com/Shows/Azure-Friday/feed/mp4high");

            XElement xmlitems = XElement.Parse(xmlResponse);
            // We need to create a list of the elements 
            List<XElement> items = xmlitems.Descendants("item").ToList();

            Debug.WriteLine("items.Count" + items.Count);

            // var reader = XmlReader.Create(new StringReader(xmlResponse));

            //var doc = XDocument.Load(reader);

            //var items = doc..Descendants("item");

            Debug.WriteLine(videos.Count);

            var mediaNs = XNamespace.Get("http://search.yahoo.com/mrss/");
            var itunesNs = XNamespace.Get("http://www.itunes.com/dtds/podcast-1.0.dtd");

            foreach (var item in items)
            {
                var video = new Video
                {
                    Title = item.Element("title").Value,
                    Description = item.Element(itunesNs + "summary").Value,
                    Duration = Convert.ToInt32(item.Element(itunesNs + "duration").Value),
                    //Category = item.Element("category").Value,
                    PublishedAt = Convert.ToDateTime(item.Element("pubDate").Value),
                    Thumbnails = new List<string>
                    {
                        item.Element(mediaNs + "thumbnail").Attribute("url").Value,
                        item.Elements(mediaNs + "thumbnail").ToList()[1].Attribute("url").Value,
                        item.Elements(mediaNs + "thumbnail").ToList()[2].Attribute("url").Value,
                        item.Elements(mediaNs + "thumbnail").ToList()[3].Attribute("url").Value,
                    },
                    //Links = new List<string>
                    //{
                    //    item.Element(mediaNs + "group").Element(mediaNs + "content").Attribute("url").Value,
                    //    item.Element(mediaNs + "group").Elements(mediaNs + "content").ToList()[1].Attribute("url").Value,
                    //    item.Element(mediaNs + "group").Elements(mediaNs + "content").ToList()[2].Attribute("url").Value,
                    //    item.Element(mediaNs + "group").Elements(mediaNs + "content").ToList()[3].Attribute("url").Value,
                    //    item.Element(mediaNs + "group").Elements(mediaNs + "content").ToList()[4].Attribute("url").Value,
                    //    item.Element(mediaNs + "group").Elements(mediaNs + "content").ToList()[5].Attribute("url").Value,
                    //},
                };

                var group = item.Element(mediaNs + "group");

                video.Links = new List<string>();

                foreach (var content in group.Elements(mediaNs + "content"))
                {
                    video.Links.Add(content.Attribute("url").Value);
                }

                Debug.WriteLine(video.Title);
                videos.Add(video);
            }
            //videos = videos.OrderBy(video => video.PublishedAt).ToList();

            Debug.WriteLine(videos.Count);
            //var employees = new List<Employee>
            //{
            //    new Employee
            //    {
            //        Name = "Hassen Ali",
            //        Department = "Human Resources",
            //    },
            //    new Employee
            //    {
            //        Name = "Mohamed Hussein",
            //        Department = "IT Department",
            //    },
            //    new Employee
            //    {
            //        Name = "Seif Abdallah",
            //        Department = "Marketing",
            //    },
            //      new Employee
            //    {
            //        Name = "Marwen Samih",
            //        Department = "Human Resources",
            //    },
            //    new Employee
            //    {
            //        Name = "Ahmed Rabiaa",
            //        Department = "IT Department",
            //    },
            //    new Employee
            //    {
            //        Name = "Othman Anouar",
            //        Department = "Marketing",
            //    },
            //};

            //return employees;

            return videos;
        }
    }
}
