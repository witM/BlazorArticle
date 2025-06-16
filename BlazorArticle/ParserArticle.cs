
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorArticle
{

    public class ParserArticle : IParserArticle
    {

        List<IParserMarker> _markers = new List<IParserMarker>();

        /*********************************************************************************
        * ARTICLES
        *********************************************************************************/

        List<ArticleFragment> IParserArticle.Parse(string rawContent, bool removeComments)
        {
            //remove html comments from article 
            if (removeComments)
                rawContent = Regex.Replace(rawContent, @"<!--.*?-->", "", RegexOptions.Singleline);

            //build patterns
            //WARNING:changing in the pattersn ad parameteres requier set propper group matching --> [..] for getting parameter value
            string[] patternsArray =
            {
                //[1]
                @"(\[\[\[VideoItem(\s+Id=""(\d+)"")?(\s+Code=""([^""]+)"")?\]\]\])",             //Id->[3], Code->[5]
                //[6]
                @"(\[\[\[Link\s+Name=""([^""]+)""(\s+PartialName=""([^""]+)"")?\s+Title=""([^""]+)""\]\]\])" 
                                                        //Name->[7], PartialName->[9], Title->[10]
            };


            string patternAll = string.Join("|", patternsArray);
            var fragments = new List<ArticleFragment>();
            ///
            //pattern meaning:
            /* \[\[  -> [[
             * Video\s+  -> Video//and one ore more spaces
             * ""a""  -> "a"
             * ()  -> //some parameter
             * ()?  -> // optional parameter -> have to be entire in ()? example: (Message=""([^""]+)"")?
             * ([^"]+)  -> //any string
             * (\d+)  -> //any digit pattern
            */
            //var regex = new Regex(patternAll);

            int lastIndex = 0;
            // this match any pattern from given array above where "match.Index" is index of first letter from matched string in entire article
            foreach (var marker in _markers)
            {
                //for one markers: match.groups[1].Value, match.groups[2].Value ... match.groups[n].Value is equivalent to 1,2,..n parameters from marker () 
                //match.Index   // index of first characther from pattern matching
                //match.Length  // Length of entire string that was matched from pattern
                //match.Value   // string of matched pattern
                /////////////////////////////////////////////////////

                var regex = new Regex(marker.StringPattern);
                var matches = regex.Matches(rawContent);
                //foreach match from the marker string pattern
                foreach (Match match in matches)
                {
                    /*********************************************************************************
                    * ADD RAW ARTICLE TEXT BEFORE EACH OF THE MARKERS (COMPONENT)
                    *********************************************************************************/
                    if (match.Index > lastIndex)
                    {
                        string html = rawContent.Substring(lastIndex, match.Index - lastIndex);
                        fragments.Add(new HtmlFragment(html));
                    }

                    /*********************************************************************************
                    * ADD PROPER COMPONENT FOR THE MARKER
                    *********************************************************************************/

                    if (marker.TryParse(match, out var type, out var parameters))
                    {
                        fragments.Add(new ComponentFragment(type, parameters));
                    }

                    //skip the marker content and get index of the first character of the article after the marker
                    lastIndex = match.Index + match.Length;


                }
                //end:foreach match

            }
            //end:foreach marker

            /*********************************************************************************
            * ADD RAW ARTICLE TEXT AFTER LAST MARKERS (COMPONENT)
            *********************************************************************************/
            if (lastIndex < rawContent.Length)
            {
                fragments.Add(new HtmlFragment(rawContent.Substring(lastIndex)));
            }

            return fragments;
        }


        /*********************************************************************************
        * MARKERS
        *********************************************************************************/
        public void RegisterComponentParser(IParserMarker marker)
        {
            _markers.Add(marker);
        }

    }

}
