using BlazorArticle;
using BlazorArticleDocs.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorArticleDocs.Services
{
    public class ArticleDocsProvider : ArticleProviderBase
    {

        public ArticleDocsProvider(NavigationManager Navigation, IHttpClientFactory ClientFactory, IOptions<AppConfig> Config, IOptions<ArticleConfig> ArticleConfig)
            : base(Navigation, ClientFactory, Config, ArticleConfig) 
        {
           
        }

        /*** ARTICLE INTERFACES ****/

        public Task<ModelArticle?> GetArticleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelArticle?> GetArticleByNameAsync(string name)
        {
            string ArticlesBasePath = _config.Value.SourceArticleDocs;
            string siteBaseUrl = _navigation.BaseUri;

            var itemDoc = _configArticle.Value.Docs.Find(e => e.Name == name);
            if (itemDoc == null) 
                return null;
            //
            ModelArticle? article = null;

            using (var client = _httpClientFactory.CreateClient("default"))
            {
                string url = $"{siteBaseUrl}{ArticlesBasePath}/{itemDoc.Name}.html";

                article = new Models.ModelArticle()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Title = itemDoc.Title,
                    Content = await client.GetStringAsync(url)

                };

                return article;
            }


        }


        public async Task<List<ModelArticle>> GetAll()
        {
            var articles = new List<ModelArticle>();
            string ArticlesBasePath = _config.Value.SourceArticleDocs;
            string siteBaseUrl = _navigation.BaseUri;

            using (var client = _httpClientFactory.CreateClient("default"))
            {
                foreach (var item in _configArticle.Value.Docs)
                {
                    string url = $"{siteBaseUrl}{ArticlesBasePath}/{item.Name}.html";

                    articles.Add(new ModelArticle()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = item.Name,
                        Title = item.Title,
                        Content = await client.GetStringAsync(url)
                    });
                }

                return articles;
            }


        }





        /*** STYLE INTERFACES ****/

        public Task<ModelArticleStyle?> GetStyleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ModelArticleStyle?> GetStyleByNameAsync(string styleName)
        {
            string ArticlesStyleBasePath = _config.Value.SourceArticleStyle;
            string siteBaseUrl = _navigation.BaseUri;

            ModelArticleStyle? style = null;
            //
            using (var client = _httpClientFactory.CreateClient("default"))
            {
                string url = $"{siteBaseUrl}{ArticlesStyleBasePath}/{styleName}.css";
                style = new ModelArticleStyle()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = styleName,
                    Content = await client.GetStringAsync(url)
                };

                return style;

            }
        }

    }
}
