using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI
{
    public class UIFader
    {
        protected readonly MonoBehaviour coroutineExecuter;
        private IColorFunction colorFunction;
        protected Graphic targetGraphic;

        public UIFader(MonoBehaviour coroutineExecuter, Graphic targetGraphic, IColorFunction colorFunction)
        {
            this.coroutineExecuter = coroutineExecuter;
            this.targetGraphic = targetGraphic;
            this.colorFunction = colorFunction;
        }

        public Coroutine Fade(Color targetColor, float duration)
        {
            Color current = targetGraphic.color;
            return coroutineExecuter.StartCoroutine(Fade(current, targetColor, duration));
        }

        protected IEnumerator Fade(Color startColor, Color endColor, float duration)
        {
            float passedTime = 0f;
            while (passedTime < duration)
            {
                targetGraphic.color = colorFunction.CalculateColor(startColor, endColor, passedTime, duration);
                passedTime += Time.deltaTime;
                yield return null;
            }
        }
    }

    public class UIFaderStartEndCommand : UIFader
    {
        public UIFaderStartEndCommand(MonoBehaviour coroutineExecuter, Graphic targetGraphic, IColorFunction colorFunction) : base(coroutineExecuter, targetGraphic, colorFunction)
        {
        }

        public Coroutine FadeCommand(Color targetColor, float duration, Command.IUpdate onStart, Command.IUpdate onEnd)
        {
            Color current = targetGraphic.color;
            return coroutineExecuter.StartCoroutine(FadeCommand(current, targetColor, duration, onStart, onEnd));
        }

        protected IEnumerator FadeCommand(Color startColor, Color endColor, float duration, Command.IUpdate onStart, Command.IUpdate onEnd)
        {
            onStart.Execute();
            IEnumerator enumerator = Fade(startColor, endColor, duration);
            yield return enumerator;
            onEnd.Execute();
        }
    }

    public class UIFaderCompositeEnumerator : UIFader
    {
        public UIFaderCompositeEnumerator(MonoBehaviour coroutineExecuter, Graphic targetGraphic, IColorFunction colorFunction) : base(coroutineExecuter, targetGraphic, colorFunction)
        {
        }

        public Coroutine FadeCompositeEnumerator(Color targetColor, float duration, IEnumerator enumerator)
        {
            Color current = targetGraphic.color;
            return coroutineExecuter.StartCoroutine(FadeCompositeEnumerator(current, targetColor, duration, enumerator));
        }

        public IEnumerator FadeCompositeEnumerator(Color startColor, Color endColor, float duration, IEnumerator enumerator)
        {
            float passedTime = 0f;
            bool isEnumeratorOnGoing = true;
            IEnumerator fade = Fade(startColor, endColor, duration);
            while (passedTime < duration)
            {
                if (isEnumeratorOnGoing)
                    isEnumeratorOnGoing = enumerator.MoveNext();
                passedTime += Time.deltaTime;
                yield return fade;
            }
        }
    }
}