using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorArticle
{
    public class ParserStyle : IParserStyle
    {

        string IParserStyle.ParseStyle(string css, bool isCompressed = false)
        {
            if (isCompressed)
            {
                // remove comments
                css = Regex.Replace(css, @"/\*.*?\*/", "", RegexOptions.Singleline);
                // remove spaces
                css = Regex.Replace(css, @"\s+", " ");
                css = css.Trim();
                return css;
            }
            else return css;

        }
    }
}