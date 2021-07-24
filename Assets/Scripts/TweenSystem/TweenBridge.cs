using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweenBridge
{
    public static Tween MoveTo(this Transform transformToMove, Transform targetPlaceholder, float duration)
    {
        return InitializeTween(TweenManager.get.MoveToSequence(transformToMove, targetPlaceholder, duration));
        
    }

    public static Tween FadeTo(this CanvasGroup canvasToFade, float targetFade, float duration)
    {
        return InitializeTween(TweenManager.get.FadeToSequence(canvasToFade, targetFade, duration));
    }


    public static Tween Shake(this Transform transformToMove, float shakeStrength, float duration)
    {
        return InitializeTween(TweenManager.get.ShakeSequence(transformToMove, shakeStrength, duration));
    }

    public static Tween AddDelay(this Tween tween, float delay)
    {
        tween.tweenDelay = delay;
        return tween;
    }

    public static Tween InitializeTween(IEnumerator tweenCallback)
    {
        Tween tween = new Tween();
        tween.tweenCallback = tweenCallback;
        tween.TweenStart();
        return tween;
    }










}


