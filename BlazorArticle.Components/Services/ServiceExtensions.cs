using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;



namespace BlazorArticle.Components.Services
{
    public static class ServiceExtensions
    {
        /// <summary>
        ///-Add default article style parser from BlazorAricle library. It is a singleton service. 
        ///-Add "ArticleHeadManager" to the services. It manage the style content in the head tag. The service is used by "ArticleStyleContent" and "ArticleStyleOutlet" components. It has to be scoped.
        /// </summary>
        /// <param name="Id">Id of the tag where the style content will be rendered. If is <c>null</c> then "article" id is used.</param>
        public static IServiceCollection AddBlazorArticleStyle(
            this IServiceCollection services, string? Id=null )
        {
            //ArticleHeadManager have to be scoped
            if (Id is null)
                Id = "article";

            //add default style parser
            services.TryAddSingleton<IParserStyle, ParserStyle>();
            //add ArticleManager
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

        /// <summary>
        /// Registers the default BlazorLibrary.Components article markers along with their corresponding components.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlazorArticleDefaultMarkers(this IServiceCollection services)
        {

            services.TryAddSingleton<RegistrationArticleMarker>(); //worning: have to be that same scoped as article parser
            return services;
        }
    }
}
