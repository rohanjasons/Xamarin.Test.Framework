using Query = System.Func<global::Xamarin.UITest.Queries.AppQuery, global::Xamarin.UITest.Queries.AppQuery>;
using WebQuery = System.Func<global::Xamarin.UITest.Queries.AppQuery, global::Xamarin.UITest.Queries.AppWebQuery>;

namespace Xamarin.Test.Framework
{
    /// <summary>
    /// Trait class that will be used to find items on the page.
    /// </summary>
    public class Trait
    {
        /// <summary>
        /// Gets query that will be used to search for the Element on the page.
        /// </summary>
        public Query Query { get; private set; }

        /// <summary>
        /// Gets webQuery that will be used to search for the Web Element on the page.
        /// </summary>
        public WebQuery WebQuery { get; private set; }

        internal bool CheckSubstring { get; private set; }

        internal string MatchText { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trait"/> class.
        /// Trait to see if the item being searched on exists.
        /// </summary>
        /// <param name="query">The query that will be used during the search for the element.</param>
        public Trait(Query query)
        {
            Query = query;
            CheckSubstring = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trait"/> class.
        /// Trait to see if the item being searched on exists.
        /// </summary>
        /// <param name="webquery">The webquery that will be used during the search for the web element.</param>
        public Trait(WebQuery webQuery)
        {
            WebQuery = webQuery;
            CheckSubstring = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trait"/> class.
        /// Search for an itme by it's string value.
        /// </summary>
        /// <param name="marked">The marked value to search for.</param>
        /// <param name="substring">The extra substring to be used to search for.</param>
        public Trait(string marked, string substring)
            : this(e => e.Marked(marked), substring)
        {
        }

        internal Trait(Query query, string substringToCheck)
            : this(query)
        {
            CheckSubstring = true;
            MatchText = substringToCheck;
        }
    }
}