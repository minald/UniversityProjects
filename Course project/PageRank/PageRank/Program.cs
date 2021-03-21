using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace PageRank
{
    class Page
    {
        public string name;

        public List<string> links;

        public double pageRank;

        public double miniRank;

        public double delta;

        public Page(string name)
        {
            this.name = name;
            links = new List<string>();
            pageRank = 1;
            delta = 1;
        }

        public Page(string name, List<string> links) : this(name)
        {
            this.links = links;
        }

        public void AddLink(string link)
        {
            links.Add(link);
        }

        public void UpdatePageRank(double d, int dimension = 1)
        {
            var newPageRank = (1 - d) / dimension + d * miniRank;
            delta = miniRank == 0 ? 0 : Math.Abs(newPageRank - pageRank);
            pageRank = newPageRank;
            miniRank = 0;
        }

        public override string ToString()
        {
            return $"Name : {name}, MR : {100 * pageRank} %";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Initialization

            double attenuationCoefficient = 0.85;
            double epsilonInPercentage = 0.001;
            var pages = new List<Page>();
            var web = new HtmlWeb();
            string directoryPath = @"C:\Users\User\Documents\Visual Studio 2017\Projects\PageRank\Pages";
            foreach(string fileName in Directory.GetFiles(directoryPath))
            {
                var page = new Page(Path.GetFileName(fileName));
                var mainNode = web.Load(fileName).DocumentNode;
                foreach(var node in mainNode.SelectNodes("//a"))
                {
                    page.AddLink(node.Attributes["href"].Value);
                }
                pages.Add(page);
            }
            NormalizePageRanks(pages);
            PrintPages("Initial values : ", pages);

            #endregion

            int i = 0;
            while(pages.Max(x => x.delta) > epsilonInPercentage / 100)
            {
                foreach(var page in pages)
                {
                    double addition = page.pageRank / page.links.Count;
                    foreach(string link in page.links)
                    {
                        if(pages.FirstOrDefault(x => x.name.Equals(link)) != null)
                        {
                            pages.FirstOrDefault(x => x.name.Equals(link)).miniRank += addition;
                        }
                    }
                }
                pages.ForEach(x => x.UpdatePageRank(attenuationCoefficient, pages.Count));
                NormalizePageRanks(pages);
                PrintPages($"Iteration №{i++ + 1} : ", pages);
            }
        }

        public static void PrintPages(string caption, List<Page> pages)
        {
            Console.WriteLine(caption);
            pages.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine();
        }

        public static void NormalizePageRanks(List<Page> pages)
        {
            double sum = pages.Sum(x => x.pageRank);
            pages.ForEach(x => x.pageRank /= sum);
        }
    }
}
