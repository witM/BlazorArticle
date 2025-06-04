using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlazorArticle.Components.Services
{
    public static class ServiceExtensions
    {
        /// <summary>
        ///  Add "ArticleHeadManager" to the services. It manage the style content in the head tag. The service is used by "ArticleStyleContent" and "ArticleStyleOutlet" components. It has to be scoped.
        /// </summary>
        /// <param name="Id">Id of the tag where the style content will be rendered. If is <c>null</c> then "article" id is used.</param>
        public static IServiceCollection AddBlazorArticleStyle(
            this IServiceCollection services, string? Id=null )
        {
            //ArticleHeadManager have to be scoped
            if (Id is null)
                Id = "article";

            services.TryAddScoped<ArticleHeadManager>(provider => new ArticleHeadManager(Id));

                //if (configureOptions is not null)
                //    services.Configure(configureOptions);

                //if (configureParser is not null)
                //    services.PostConfigure<IArticleParser>(parser =>
                //    {
                //        configureParser(parser);
                //    });

                return services;
        }
    }
}
