using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float scorePerUnitHeight;
    
    private const string BEST_SCORE = "best_score";

    private int currentValue;
    public int CurrentValue => currentValue;

    public void SetScoreByHeight(float height)
    {
        currentValue = Mathf.FloorToInt(height * scorePerUnitHeight);
    }
        
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BEST_SCORE, 1000);
    }

    public void SetBestScore(int value)
    {
        PlayerPrefs.SetInt(BEST_SCORE, value);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        currentValue = 0;
    }
}