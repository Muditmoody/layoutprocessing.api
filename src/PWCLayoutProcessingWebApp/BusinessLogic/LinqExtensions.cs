namespace PWCLayoutProcessingWebApp.BusinessLogic
{
    public static class LinqExtensions
    {
        public static (IEnumerable<T> selected, IEnumerable<T> notSelected) PartitionBy<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            IEnumerable<T> selected = null;
            IEnumerable<T> notSelected = null;

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
