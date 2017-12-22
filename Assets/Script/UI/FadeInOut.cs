using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut {
    //协程适用于同一时间只运行一份函数的情况,如果同一时间运行多份同一个协程就会难以管理
    public static IEnumerator FadeImage(Image target, float duration, Color color)
    {
        if (target == null)
            yield break;
        float alpha = target.color.a;
        //渐变消失
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            if (target == null)
                yield break;
            Color targetColor = new Color(color.r, color.g, color.b, Mathf.SmoothStep(alpha, color.a, t));
            target.color = targetColor;
            yield return null;
        }
        target.color = color;
    }
    
}
