using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    public ScoreUI score;

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
}
