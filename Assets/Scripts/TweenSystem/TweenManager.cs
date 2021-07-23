using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TweenManager : Singleton<TweenManager>
{
    public float EPSILON = Mathf.Epsilon;

    [Header("Global animation parameters")]
    public float fadeSpeed = 1f;

    public IEnumerator MoveToSequence(Transform transformToMove, Transform target, float lerpFactor)
    {
        while (Vector3.Distance(transformToMove.position, target.transform.position) > EPSILON)
        {
            transformToMove.position = Vector3.Lerp(transformToMove.position, target.position, lerpFactor);
            yield return null;
        }
        transformToMove.position = target.transform.position;
    }

    public IEnumerator FadeTo(CanvasGroup canvasGroup, float targetFade)
    {

        if (canvasGroup.alpha < targetFade)
        {
            yield return IncreaseFadeTo(canvasGroup, targetFade);
        }
        else
        {
            yield return DecreaseFadeTo(canvasGroup, targetFade);
        }
        canvasGroup.alpha = targetFade;
    }

    public IEnumerator IncreaseFadeTo(CanvasGroup canvasGroup, float targetFade)
    {
        while (canvasGroup.alpha < targetFade)
        {
            canvasGroup.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator DecreaseFadeTo(CanvasGroup canvasGroup, float targetFade)
    {
        while (canvasGroup.alpha > targetFade)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
public class Tween
{
    public IEnumerator tweenCallback;
    public float tweenDelay;

    public void TweenStart()
    {
        TweenManager.get.StartCoroutine(TweenSequence());
    }

    public IEnumerator TweenSequence()
    {
        yield return new WaitForEndOfFrame();
        if (tweenDelay > 0)
            yield return new WaitForSeconds(tweenDelay);
        yield return tweenCallback;
    }
}