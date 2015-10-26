
using System;
using System.Collections.Generic;

namespace AzureFriday.Models
{
    /// <summary>
    /// The Employee model contains information about the Name and the Department.
    /// </summary>
    public class Video
    {

        public string Title
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public List<string> Thumbnails
        {
            get; set;
        }

        public List<string> Links
        {
            get; set;
        }

        public DateTime PublishedAt
        {
            get; set;
        }

        public int Size
        {
            get; set;
        }

        public string Category { get; set; }

        public int Duration { get; set; }
    }
}
