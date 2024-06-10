namespace MonoGame.Utils.Extensions;

public static class CollectionExt
{
    public static bool Empty<T>(this ICollection<T> list) => list.Count == 0;
}