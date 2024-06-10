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
}
