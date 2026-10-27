using UnityEngine;
using System.Collections.Generic;

public class TweenHandler : MonoBehaviour
{
    private Tween activeTween;
    
    void Update()
    {
        if (activeTween != null)
        {
            if (activeTween.Elapsed < activeTween.Duration)
            {
                activeTween.Elapsed += Time.deltaTime;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, activeTween.Elapsed / activeTween.Duration);
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }
    }

    public void AddTween(Transform target, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(target, startPos, endPos, duration);
        }
    }
}
