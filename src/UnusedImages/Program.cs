using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Majestic13;
using Markdig;

namespace UnusedImages
{
    class Program
    {
        private static readonly List<string> Extensions = new List<string>
        {
            "*.jpg",
            "*.png",
            "*.gif",
            "*.jpeg"
        };
        static void Main(string[] args)
        {
            var rootFolderPath = ConfigurationManager.AppSettings["MarkdownPath"];

            var images = new List<string>();

            foreach (var extension in Extensions)
            {
                images.AddRange(Directory.GetFiles(rootFolderPath, extension, SearchOption.AllDirectories).ToList());
            }

            foreach (var markdown in Directory.GetFiles(rootFolderPath, "*.md", SearchOption.AllDirectories))
            {
                var fileContent = File.ReadAllText(markdown);

                var markdownTags = Markdown.Parse(markdown);

                var htmlContent = Markdown.ToHtml(fileContent);
                var nodes = new HtmlParser().Parse(htmlContent);

                FindImages(nodes);
            }
            

            Console.ReadKey();
        }

        private static List<string> FindImages(object nodeList)
        {
            var node = nodeList as HtmlNode;

            //if(node)

            return null;
        }
    }
}
