using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TweenManager : Singleton<TweenManager>
{
    public float EPSILON = Mathf.Epsilon;

    [Header("Global animation parameters")]
    public float fadeSpeed = 1f;

    public AnimationCurve globalAnimationCurve;

    private void Start()
    {
    }

    public IEnumerator MoveToSequence(Transform transformToMove, Transform target, float duration)
    {
        float distance = Vector3.Distance(transformToMove.position, target.position);
        float incrementPerSecond =  distance/ duration;

        float normalizedCounter = 0;
        float timeCounter = 0;
        while (Vector3.Distance(transformToMove.position, target.position) > incrementPerSecond * Time.deltaTime)
        {
            normalizedCounter = timeCounter / duration;
            Vector3 incrementPosition = (target.position - transformToMove.position).normalized * (incrementPerSecond * Time.deltaTime);// * ApplyEasing(normalizedCounter);
            transformToMove.position = transformToMove.position + incrementPosition;

            yield return null;
            timeCounter += Time.deltaTime;
        }
        transformToMove.position = target.transform.position;
    }

    public float ApplyEasing(float normalizedCounter)
    {
        return (1 + globalAnimationCurve.Evaluate(normalizedCounter) - normalizedCounter);
    }

    public IEnumerator FadeToSequence(CanvasGroup canvasGroup, float targetFade, float duration)
    {

        if (canvasGroup.alpha < targetFade)
        {
            yield return IncreaseFadeTo(canvasGroup, targetFade, duration);
        }
        else
        {
            yield return DecreaseFadeTo(canvasGroup, targetFade, duration);
        }
        canvasGroup.alpha = targetFade;
    }

    public IEnumerator IncreaseFadeTo(CanvasGroup canvasGroup, float targetFade, float duration)
    {
        float stepPerSecond = (targetFade - canvasGroup.alpha) / duration;
        while ((targetFade -canvasGroup.alpha) > stepPerSecond *Time.deltaTime )
        {
            canvasGroup.alpha += stepPerSecond * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator DecreaseFadeTo(CanvasGroup canvasGroup, float targetFade, float duration)
    {
        float stepPerSecond = (targetFade - canvasGroup.alpha) / duration;
        while ((targetFade - canvasGroup.alpha) < stepPerSecond * Time.deltaTime)
        {
            canvasGroup.alpha += stepPerSecond * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator ShakeSequence(Transform transformToMove, float shakeStrength, float duration)
    {
        float counter = 0;
        Vector3 originalPosition = transformToMove.position;
        Vector3 randomShake = Vector3.zero;
        while( counter < duration)
        {
            randomShake.x = Random.Range(-1f, 1f);
            randomShake.y = Random.Range(-1f, 1f);
            //randomShake.z = Random.Range(-1, 1);

            transformToMove.position = originalPosition + randomShake * shakeStrength;
            yield return null;
            counter += Time.deltaTime;
        }
        transformToMove.position = originalPosition;
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