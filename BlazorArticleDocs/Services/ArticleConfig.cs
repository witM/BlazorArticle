﻿namespace BlazorArticleDocs.Services
{
    public class DocItem
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; }
        public int[] Versions { get; set; } = new int[0];
        public int Order { get; set; }
    }

    public class ArticleConfig
    {
        //List of article name from examples
        public List<string> Examples { get; set; } = new();
        //List of docs articles
        public List<DocItem> Docs { get; set; } = new();
    }
}
