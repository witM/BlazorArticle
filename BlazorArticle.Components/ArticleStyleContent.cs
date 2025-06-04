using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle.Components
{
    /// <summary>
    /// Provide the style content that will be rendered in the place of the "ArticleStyleOutlet" component.
    /// WARNING:This component have to be rendered in the same render mode as "ArticleStyleOutlet" component.
    /// INFO: If the page is rendered in InteractiveServer mode, you can omit the UseJavascript parameter and simply choose whether to enable style prerendering by "IsPrerendered" parameter. These options are available to provide flexibility and address issues with stream rendering.
    /// </summary>
    public partial class ArticleStyleContent
    {
    }
}
