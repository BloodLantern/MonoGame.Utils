using Microsoft.Xna.Framework;

namespace MonoGame.Utils.Extensions;

public static class ColorExt
{
    public static Color Inverse(this Color color)
    {
            int r = 255 - color.R;
            int g = 255 - color.G;
            int b = 255 - color.B;

            return new Color(r, g, b, color.A);
        }

    public static void ToHsv(this Color color, out float hue, out float saturation, out float value)
    {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float delta = max - min;

            hue = 0f;
            if (delta != 0f)
            {
                if (Calc.FloatEquals(max, r))
                    hue = (g - b) / delta;
                else if (Calc.FloatEquals(max, g))
                    hue = 2f + (b - r) / delta;
                else if (Calc.FloatEquals(max, b))
                    hue = 4f + (r - g) / delta;

                hue *= 60f;
                if (hue < 0f)
                    hue += 360f;
            }

            saturation = max == 0f ? 0f : delta / max;
            value = max;
        }
}
