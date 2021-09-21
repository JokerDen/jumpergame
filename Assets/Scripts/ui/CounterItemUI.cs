using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CounterItemUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Text label;
    public float duration;

    public void Show(int num)
    {
        transform.localScale = Vector3.zero;
        label.text = num.ToString();
        gameObject.SetActive(true);
        transform.DOScale(1f, duration);
        canvasGroup.DOFade(0f, duration).OnComplete(SelfDestroy);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
