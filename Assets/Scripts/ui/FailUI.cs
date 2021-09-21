using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    public Button restartButton;

    public ScoreUI playerScore;
    public ScoreUI bestScore;

    public GameObject newBest;
    public Text bestText;

    public float showDelay;
    public float bestDuration;
    
    void Start()
    {
        restartButton.onClick.AddListener(GameManager.current.RestartGameplay);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        restartButton.gameObject.SetActive(false);
        playerScore.Hide();
        bestScore.Hide();
        newBest.SetActive(false);

        StartCoroutine(ShowAnim());
    }

    private IEnumerator ShowAnim()
    {
        yield return new WaitForSeconds(showDelay);

        var best = GameManager.current.score.GetBestScore();
        bestScore.Show(best);

        yield return new WaitForSeconds(showDelay);

        var score = GameManager.current.score.CurrentValue;

        var dur = bestDuration * Mathf.Clamp01((float)score / best);
        
        playerScore.Show(0);
        
        playerScore.ShowCount(score, dur/*, () => 
        {
            var c = bestText.color;
            Color.RGBToHSV(c, out float H, out float S, out float V);
            c = Color.HSVToRGB(Random.value, S, V);
            bestText.color = c;
        }*/);

        if (score < best)
            yield return new WaitForSeconds(dur);
        else
        {
            float noBestDur = ((float)best / score) * dur;
            yield return new WaitForSeconds(noBestDur);
            newBest.SetActive(true);
            var bestDur = dur - noBestDur;
            bestScore.ShowCount(score, bestDur);
            
            GameManager.current.score.SetBestScore(score);
            
            yield return new WaitForSeconds(bestDur);
        }
        
        restartButton.gameObject.SetActive(true);
    }
}
