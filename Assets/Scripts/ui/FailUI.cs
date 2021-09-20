using UnityEngine;
using UnityEngine.UI;

public class FailUI : MonoBehaviour
{
    public Button restartButton;
    
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
    }
}
