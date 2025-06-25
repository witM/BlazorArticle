using BlazorArticle;

namespace BlazorArticleDocs.Models
{
    public class ModelArticle : ModelArticleBase<string>
    {
        public int Version { get; set; }
    }
 


    public class ModelArticleStyle : ModelStyleBase<string>
    {}
}
