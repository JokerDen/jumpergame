using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    public ScoreUI score;
    public CounterItemUI counterItemSample;

    private void Update()
    {
        score.Show(GameManager.current.score.CurrentValue);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowTouch(Vector3 transformPosition, int touchedCount)
    {
        // var cam = Camera.current;
        var cam = GameManager.current.cam.cam;
        var screenPoint = RectTransformUtility.WorldToScreenPoint(cam, transformPosition);
        var rectTransform = GetComponent<RectTransform>();
        Vector2 locPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, cam, out locPos);

        var item = Instantiate(counterItemSample, locPos, Quaternion.identity, rectTransform);
        // item.GetComponent<RectTransform>().anchoredPosition = locPos;
        item.GetComponent<RectTransform>().localPosition = locPos;
        item.Show(touchedCount);
    }
}
