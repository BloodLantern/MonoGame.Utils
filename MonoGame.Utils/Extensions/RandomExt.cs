using Microsoft.Xna.Framework;

namespace MonoGame.Utils.Extensions;

public static class RandomExt
{
    /// <summary>
    /// Returns a Vector2 that has both its component grater or equal to 0.0 and less than 1.0
    /// </summary>
    /// <param name="random">The Random instance</param>
    /// <returns>A random Vector2</returns>
    public static Vector2 NextVector2(this Random random) => new(random.NextSingle(), random.NextSingle());

    public static T Choose<T>(this Random random, T a, T b) => Calc.GiveMe(random.Next(2), a, b);

    public static T Choose<T>(this Random random, T a, T b, T c) => Calc.GiveMe(random.Next(3), a, b, c);

    public static T Choose<T>(this Random random, T a, T b, T c, T d) => Calc.GiveMe(random.Next(4), a, b, c, d);

    public static T Choose<T>(this Random random, T a, T b, T c, T d, T e) => Calc.GiveMe(random.Next(5), a, b, c, d, e);

    public static T Choose<T>(this Random random, T a, T b, T c, T d, T e, T f) => Calc.GiveMe(random.Next(6), a, b, c, d, e, f);

    public static T Choose<T>(this Random random, List<T> choices) => choices[random.Next(choices.Count)];
}
