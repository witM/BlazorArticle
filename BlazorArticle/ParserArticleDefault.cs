
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace BlazorArticle
{
    /// <summary>
    /// Set options for article parser
    /// </summary>
    public class ParserOptions
    {
        /// <summary>
        /// List of markers to parsing within the article
        /// </summary>
        public List<IParserMarker> Markers = new List<IParserMarker>();
    }

    /// <summary>
    /// Default parser service.
    /// </summary>
    public class ParserArticleDefault : IParserArticle
    {

        private readonly IOptions<ParserOptions> _options;

        public ParserArticleDefault(IOptions<ParserOptions> options)
        {
            _options = options;
            //_markers = (options.Value.Markers is null) ? new List<IParserMarker>() : options.Value.Markers;
        }

        /// <summary>
        /// Parses the article content. For now only html content.
        /// </summary>
        /// <param name="content">Article content.</param>
        /// <param name="removedComments">Determines whether to remove comments from the source of the rendered article.</param>
        /// <returns>A list of render fragments to be rendered.</returns>
        List<ArticleFragment> IParserArticle.Parse(string content, bool removeComments)
        {
            content = PreParsing(content, removeComments);
            //
            return Parse(content, removeComments);
        }
        
        string PreParsing(string content, bool removeComments)
        {
            //remove html comments from article 
            if (removeComments)
                content = Regex.Replace(content, @"<!--.*?-->", "", RegexOptions.Singleline);
            //
            return content;
        }

        List<ArticleFragment> Parse(string content, bool removeComments)
        {
            //var markers = _options.Value.Markers;

            var matchesAll = GetAllMatchesSorted(content);

            //string patternAll = string.Join("|", patternsArray);
            var fragments = new List<ArticleFragment>();

            int lastIndex = 0;
            // this match any pattern from given array above where "match.Index" is index of first letter from matched string in entire article
            foreach (var (marker, match) in matchesAll)
            {
                //for one markers: match.groups[1].Value, match.groups[2].Value ... match.groups[n].Value is equivalent to 1,2,..n parameters from marker () 
                //match.Index   // index of first characther from pattern matching
                //match.Length  // Length of entire string that was matched from pattern
                //match.Value   // string of matched pattern
                /////////////////////////////////////////////////////

                //var regex = new Regex(marker.StringPattern);
                //var matches = regex.Matches(content);
                //foreach match from the marker string pattern
                //foreach (Match match in matches)
                {
                    /*********************************************************************************
                    * ADD RAW ARTICLE TEXT BEFORE EACH OF THE MARKERS (COMPONENT)
                    *********************************************************************************/
                    if (match.Index > lastIndex)
                    {
                        string html = content.Substring(lastIndex, match.Index - lastIndex);
                        fragments.Add(new HtmlFragment(html));
                    }

                    /*********************************************************************************
                    * ADD PROPER COMPONENT FOR THE MARKER
                    *********************************************************************************/

                    if (marker.TryParse(match, out var type, out var parameters))
                    {
                        fragments.Add(new ComponentFragment(type, parameters));
                    }

                    //skip the marker content text and get index of the first character of the article after the marker
                    lastIndex = match.Index + match.Length;


                }
                //end:foreach match

            }
            //end:foreach marker

            /*********************************************************************************
            * ADD RAW ARTICLE TEXT AFTER LAST MARKERS (COMPONENT)
            *********************************************************************************/
            if (lastIndex < content.Length)
            {
                fragments.Add(new HtmlFragment(content.Substring(lastIndex)));
            }

            return fragments;
        }

        IOrderedEnumerable<(IParserMarker, Match)> GetAllMatchesSorted(string content)
        {
            
            var allMatches = new List<(IParserMarker Marker, Match Match)>();

            foreach (var marker in _options.Value.Markers)
            {
                var regex = new Regex(marker.StringPattern);
                var matches = regex.Matches(content);

                foreach (Match match in matches)
                {
                    allMatches.Add((marker, match));
                }
            }

            return allMatches.OrderBy(m => m.Match.Index);
        }



        /// <summary>
        /// Registers a marker parser that will be used to render a text marker as a component render fragment.
        /// </summary>
        /// <param name="marker">Marker parser</param>
        public void RegisterComponentParser(IParserMarker marker)
        {
            var markers = _options.Value.Markers;
            markers.Add(marker);
        }

    }

}
