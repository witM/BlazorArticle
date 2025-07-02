using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BlazorArticle;

namespace BlazorArticleWebClient.Shared.ArticleComponents
{
    internal class AlertYellowCounter_Parser : IParserMarker
    {
        public string MarkerName { get; private set; } = "AlertYellowCounter";

        public string StringPattern { get; private set; } = @"(\[\[\[AlertYellowCounter(\s+Counter=""(\d+)"")?\]\]\])";

        public bool TryParse(Match match, out Type componentType, out Dictionary<string, object>? parameters)
        {
            //WARNING: The group[0] contains all match from string,
            //group[1] contains first match of () in the string pattern: (\[\[\[AlertCounter(\s+Counter=""(\d+)"")?\]\]\])
            ////////////////////////////////////////////////////
            
            componentType = typeof(AlertYellowCounter);
            //parameters maybe set to null
            parameters = null;
            //if the "Counter" parameter is set
            if (match.Groups[2].Success)
            {
                parameters = new Dictionary<string, object>();
                if(int.TryParse(match.Groups[3].Value, out var Counter))
                {
                    parameters.Add("Counter", Counter);
                }
                
            }
            return true;
        }
    }
}
