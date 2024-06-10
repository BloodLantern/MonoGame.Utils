using Microsoft.Xna.Framework;

namespace MonoGame.Utils.Extensions;

public static class PointExt
{
    public static Point Mul(this Point self, float factor) => new((int)(self.X * factor), (int)(self.Y * factor));

    public static Point Div(this Point self, float factor) => new((int)(self.X / factor), (int)(self.Y / factor));
}