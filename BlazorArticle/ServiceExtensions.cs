using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{
    public static class ServiceExtensions
    {
        /// <summary>
        ///  Add BlazorArticle default parser from the library as the service. It is singleton service.
        /// </summary>
        public static IServiceCollection AddBlazorArticle(
            this IServiceCollection services)
        {


            services.TryAddSingleton<IParserArticle, ArticleParser>();

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
