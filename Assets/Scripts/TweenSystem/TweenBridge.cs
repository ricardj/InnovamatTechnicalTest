using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweenBridge
{
    public static Tween MoveTo(this Transform transformToMove, Transform targetPlaceholder, float lerpFactor)
    {
        Tween tween = new Tween();
        tween.tweenCallback = TweenManager.get.MoveToSequence(transformToMove, targetPlaceholder, lerpFactor);
        tween.TweenStart();
        return tween;
    }

    public static Tween FadeTo(this CanvasGroup canvasToFade, float targetFade)
    {
        Tween tween = new Tween();
        tween.tweenCallback = TweenManager.get.FadeToSequence(canvasToFade, targetFade);
        tween.TweenStart();
        return tween;
    }



    public static Tween AddDelay(this Tween tween, float delay)
    {
        tween.tweenDelay = delay;
        return tween;
    }




}


