using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorArticle
{


    /// <summary>
    /// Base interface for a marker parser that replaces markers with appropriate components during article rendering.
    /// </summary>
    public interface IParserMarker
    {
        /// <summary>
        /// Unique marker name.
        /// </summary>
        string MarkerName { get; }

        /// <summary>
        /// Regex pattern of marker. Marker should be written as: [[[{MarkerName} {par1}="{par1_value}" {par2}="{par2_value}" ... {par_n}="{par_n_value}"]]] but parser interface is more general than that. This may change in the future;
        /// </summary>
        string StringPattern { get; }

        /// <summary>
        /// Sets proper component and it's parameters.
        /// </summary>
        /// <param name="match"></param>
        /// <param name="componentType"></param>
        /// <returns></returns>
        bool TryParse(Match match, out Type componentType, out Dictionary<string, object>? parameters);
    }
}
