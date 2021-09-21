using DG.Tweening;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float toScale;
    public float inDuration;
    public float outDuration;
    public Ease inEase;
    public Ease outEase;

    private void Start()
    {
        DoIn();
    }

    private void DoIn()
    {
        transform.DOScale(toScale, inDuration).SetEase(inEase).OnComplete(DoOut);
    }

    private void DoOut()
    {
        transform.DOScale(1f, outDuration).SetEase(outEase).OnComplete(DoIn);
    }
}
