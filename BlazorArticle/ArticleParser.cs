
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorArticle
{

    /*
     * This parser works with statically implemented Component to render in article with hard coded markers parsing.
     * Set list of markers in "patternArray" and proper components to match to them, make sure you parsing proper regex group parameter with proper component parameter
     */


    public class ArticleParser : IParserArticle
    {
        List<ArticleFragment> IParserArticle.Parse(string rawContent, bool removedComments)
        {
            //remove html comments from article 
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
            var regex = new Regex(patternAll);
            var matches = regex.Matches(rawContent);

            int lastIndex = 0;
            // this match any pattern from given array above where "match.Index" is index of first letter from matched string in entire article
            foreach (Match match in matches) 
            {
                //for one markers: match.groups[1].Value, match.groups[2].Value ... match.groups[n].Value is equivalent to 1,2,..n parameters from marker () 
                //match.Index   // index of first characther from pattern matching
                //match.Length  // Length of entire string that was matched from pattern
                //match.Value   // string of matched pattern
                /////////////////////////////////////////////////////

                /*********************************************************************************
                 * ADD RAW ARTICLE TEXT BEFORE EACH OF THE MARKERS (COMPONENT)
                *********************************************************************************/
                if (match.Index > lastIndex)
                {
                    string html = rawContent.Substring(lastIndex, match.Index - lastIndex);
                    fragments.Add(new HtmlFragment(html));
                }

                /*********************************************************************************
                 * ADD PROPER COMPONENT
                *********************************************************************************/

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                /***** VideoItem *******/
                if (match.Groups[1].Success)
                {
                    var Code = match.Groups[5].Value;
                    parameters.Add("Code", Code);
                    if (int.TryParse(match.Groups[3].Value, out int Id))
                    {
                        parameters.Add("Id", Id);
                    }
                    //
                    //fragments.Add(new ComponentFragment(typeof(VideoItemArticleContext), parameters));

                }
                ///***** VideoGroup  *******/
                if (match.Groups[6].Success)
                {
                    var Code = match.Groups[7].Value;
                    parameters.Add("Code", Code);
                    //fragments.Add(new ComponentFragment(typeof(VideoGroupContext), parameters));
                }

                /***** Link *******/
                if (match.Groups[8].Success)
                {
                    var Name = match.Groups[9].Value;
                    var PartialName = match.Groups[11].Value;
                    var Title = match.Groups[12].Value;
                    parameters.Add("Name", Name);
                    parameters.Add("PartialName", PartialName);
                    parameters.Add("Title", Title);
                    //
                    //fragments.Add(new ComponentFragment(typeof(ArticleLink), parameters));
                }

                /*********************************************************/

                lastIndex = match.Index + match.Length;                 //Set "lastIndex" on first character after the markers string
            }
            //END OF MARKERS IN THE ARTICLE (END OF LOOP)

            /*********************************************************************************
            * ADD RAW ARTICLE TEXT AFTER LAST MARKERS (COMPONENT)
            *********************************************************************************/
            if (lastIndex < rawContent.Length)
            {
                string html = rawContent.Substring(lastIndex);
                fragments.Add(new HtmlFragment(html));
                //fragments.Add(new HtmlFragment(rawContent.Substring(lastIndex)));
            }

            return fragments;
        }

        string IParserArticle.ParseStyle(string css, bool isCompressed=false)
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
