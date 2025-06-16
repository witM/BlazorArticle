using BlazorArticle;
using Microsoft.EntityFrameworkCore;

using BlazorArticleWeb.Models;


namespace BlazorArticleWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ModelArticle> Articles{ get; set; } 
        public DbSet<ModelArticleStyle> ArticleStyles{ get; set; }
    }

    


}
