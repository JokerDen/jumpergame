using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text label;
    
    private int currentValue;
    private TweenerCore<int, int, NoOptions> tween;

    public void Show(int score)
    {
        currentValue = score;
        ShowCurrent();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowCount(int score, float duration)
    {
        if (tween != null)
            tween.Kill(); 
        tween = DOTween.To(() => currentValue, x => currentValue = x, score, duration).SetEase(Ease.Linear)
            .OnUpdate(ShowCurrent).OnComplete(ShowCurrent);
    }

    private void ShowCurrent()
    {
        label.text = currentValue.ToString();
        gameObject.SetActive(true);
    }
}
