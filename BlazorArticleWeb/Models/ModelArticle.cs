using BlazorArticle;
using System.ComponentModel.DataAnnotations.Schema;

//[NotMapped]

namespace BlazorArticleWeb.Models
{
    public class ModelArticle : ModelArticleBase<int>
    {
        public int? _StyleId { get; set; }
        public ModelArticleStyle? _Style { get; set; }
    }

    public class ModelArticleStyle : ModelStyleBase<int>
    {
        public List<ModelArticle> _Articles { get; set; } = new();
    }
}
