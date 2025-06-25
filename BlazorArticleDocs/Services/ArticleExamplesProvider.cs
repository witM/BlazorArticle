using BlazorArticle;
using BlazorArticleDocs.Models;
using BlazorArticleDocs.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Xml.Linq;

namespace BlazorArticleDocs.Services
{
    public class ArticleExamplesProvider : ArticleProviderBase,  IArticleProvider<ModelArticle, string>
    {

        public ArticleExamplesProvider(NavigationManager Navigation, IHttpClientFactory ClientFactory, IOptions<AppConfig> Config, IOptions<ArticleConfig> ArticleConfig)
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
            string ArticlesBasePath = _config.Value.SourceArticleExamples;
            string siteBaseUrl = _navigation.BaseUri;

            ModelArticle? article = null;

            using (var client = _httpClientFactory.CreateClient("default"))
            {
                string url = $"{siteBaseUrl}{ArticlesBasePath}/{name}.html";

                article = new Models.ModelArticle()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Content = await client.GetStringAsync(url)

                };

                return article;
            }


        }

        public async Task<List<ModelArticle>> GetAll()
        {
            var articles = new List<ModelArticle>();
            string ArticlesBasePath = _config.Value.SourceArticleExamples;
            string siteBaseUrl = _navigation.BaseUri;

            using (var client = _httpClientFactory.CreateClient("default"))
            {
                foreach (var name in _configArticle.Value.Examples)
                {
                    string url = $"{siteBaseUrl}{ArticlesBasePath}/{name}.html";

                    articles.Add(new ModelArticle()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = name,
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
