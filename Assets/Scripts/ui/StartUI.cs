using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public Text timerText;
    public int introDuration;

    public Transform animContainer;

    private Coroutine showAnim;

    public float showAnimDuration;
    public Ease showAnimEase;

    public void Show()
    {
        gameObject.SetActive(true);
        animContainer.gameObject.SetActive(false);
    }

    public void ShowIntro(Action callback)
    {
        if (showAnim != null)
            StopCoroutine(showAnim);
        showAnim = StartCoroutine(ShowAnim(callback));
    }

    private IEnumerator ShowAnim(Action callback)
    {
        animContainer.gameObject.SetActive(true);
        
        for (int i = 0; i < introDuration; i++)
        {
            int left = introDuration - i;
            timerText.text = left.ToString();
            
            animContainer.DOKill();
            animContainer.localScale = Vector3.zero;
            animContainer.DOScale(1f, showAnimDuration).SetEase(showAnimEase);
            
            yield return new WaitForSeconds(1f);
        }
        
        callback.Invoke();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
