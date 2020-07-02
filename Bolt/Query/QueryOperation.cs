namespace Lasm.BoltExtensions
{
    /// <summary>
    /// An enum of Linq query operations.
    /// </summary>
    public enum QueryOperation
    {
        Any,
        AnyWithCondition,
        First,
        FirstOrDefault,
        OrderBy,
        OrderByDescending,
        Single,
        Where
    }
}