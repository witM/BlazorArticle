using BlazorArticle;
using BlazorArticleDocs.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace BlazorArticleDocs.Services
{
    public abstract class ArticleProviderBase : IArticleProvider<ModelArticle, string>, IArticleStyleProvider<ModelArticleStyle, string>
    {
        protected readonly NavigationManager _navigation;
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IOptions<AppConfig> _config;
        protected readonly IOptions<ArticleConfig> _configArticle;


        public ArticleProviderBase(NavigationManager Navigation, IHttpClientFactory ClientFactory, IOptions<AppConfig> Config, IOptions<ArticleConfig> ConfigArticle)
        {
            _navigation = Navigation;
            _httpClientFactory = ClientFactory;
            _config = Config;
            _configArticle = ConfigArticle;
        }

        public Task<ModelArticle> GetArticleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelArticle> GetArticleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ModelArticleStyle> GetStyleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelArticleStyle> GetStyleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
