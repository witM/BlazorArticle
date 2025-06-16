using BlazorArticle;
using BlazorArticleWeb.Data;
using BlazorArticleWeb.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Xml.Linq;


namespace BlazorArticleWeb.Services
{
    public class ArticleProviderSite : IArticleProvider<ModelArticle, int>, IArticleStyleProvider<ModelArticleStyle, int>
    {

        //readonly NavigationManager _navigation;
        readonly ApplicationDbContext _context;
        //readonly IOptions<AppConfig> _config;

        public ArticleProviderSite(ApplicationDbContext context)
        {
            //_navigation = Navigation;
            _context = context;
            //_config = Config;
        }

        /*** ARTICLE INTERFACES ****/

        public async Task<ModelArticle> GetArticleAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<ModelArticle> GetArticleByNameAsync(string name)
        {
            return await _context.Articles.SingleOrDefaultAsync(e => e.Name == name);

        }

        /*** STYLE INTERFACES ****/

        public async Task<ModelArticleStyle> GetStyleAsync(int id)
        {
            return await _context.ArticleStyles.FindAsync(id);
        }

        public async Task<ModelArticleStyle> GetStyleByNameAsync(string styleName)
        {
            return await _context.ArticleStyles.SingleOrDefaultAsync(e => e.Name == styleName);
        }

    }
}

