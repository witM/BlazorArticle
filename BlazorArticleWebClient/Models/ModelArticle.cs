using BlazorArticle;

namespace BlazorArticleWebClient.Models
{
    public class ModelArticle : IArticle<string>
    {
        public string Id { get; set; }

        public string? Name {  get; set; }

        public string? Content {  get; set; }
    }


    public class ModelArticleStyle : ModelStyleBase<string>
    {}
}
