namespace PWCLayoutProcessingWebApp.BusinessLogic
{
#nullable enable

    /// <summary>
    /// The linq extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Partitions the items by predicate logic
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="predicate">The predicate for match condition</param>
        /// <returns>A (IEnumerable&lt;T&gt; selected, IEnumerable&lt;T&gt; notSelected) .</returns>
        public static (IEnumerable<T> selected, IEnumerable<T> notSelected) PartitionBy<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            IEnumerable<T>? selected = null;
            IEnumerable<T>? notSelected = null;

            foreach (var g in items.GroupBy(predicate))
            {
                if (g.Key)
                {
                    selected = g;
                }
                else
                {
                    notSelected = g;
                }
            }

            return (selected ?? Enumerable.Empty<T>(),
                            notSelected ?? Enumerable.Empty<T>());
        }
    }
}