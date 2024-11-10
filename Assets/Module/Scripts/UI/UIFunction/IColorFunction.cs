using UnityEngine;

namespace UI
{
    public interface IColorFunction
    {
        public Color CalculateColor(Color startColor, Color endColor, float passedTime, float duration);
    }

    public class ColorFunctionLinear : IColorFunction
    {
        Color IColorFunction.CalculateColor(Color startColor, Color endColor, float passedTime, float duration)
        {
            Color result = Color.Lerp(startColor, endColor, passedTime / duration);
            return result;
        }
    }

    public class ColorFunctionCurve : IColorFunction
    {
        private readonly AnimationCurve animationCurve;

        public ColorFunctionCurve(AnimationCurve animationCurve)
        {
            this.animationCurve = animationCurve;
        }

        Color IColorFunction.CalculateColor(Color startColor, Color endColor, float passedTime, float duration)
        {
            Color result;

            result.r = Calculate(startColor.r, endColor.r, passedTime / duration);
            result.g = Calculate(startColor.g, endColor.g, passedTime / duration);
            result.b = Calculate(startColor.b, endColor.b, passedTime / duration);
            result.a = Calculate(startColor.a, endColor.a, passedTime / duration);

            return result;
        }

        private float Calculate(float start, float end, float ratio)
        {
            return start + (end - start) * animationCurve.Evaluate(ratio);
        }
    }
}