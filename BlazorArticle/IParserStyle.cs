using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorArticle
{

    public interface IParserStyle
    {
        /// <summary>
        ///  Parses the article's style content.
        /// </summary>
        /// <param name="css">Content of the style.</param>
        /// <param name="isCompressed">Decides whether to remove comments and white spaces from the source of the rendered style.</param>
        /// <returns>Parsed css style.</returns>
        string ParseStyle(string css, bool isCompressed);
    }
}
