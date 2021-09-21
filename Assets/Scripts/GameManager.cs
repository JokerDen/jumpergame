using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerCharacter player;
    public PlayerInput input;

    public ScoreManager score;

    public GameLevel level;
    public GameUI ui;
    public GameCamera cam;

    private bool started;

    private float playerHeight;
    public float PlayerHeight => playerHeight;

    public static GameManager current;

    public float failHeight;

    private void Awake()
    {
        current = this;
        
        Application.targetFrameRate = 60;
        // Time.fixedDeltaTime = 0.02f;
        // Time.fixedDeltaTime = 1f / 30f;
    }

    private void Start()
    {
        RestartGameplay();
    }

    public void RestartGameplay()
    {
        bool notFirst = started;
        started = false;
        player.Reset();
        score.Reset();
        cam.Reset();
        level.Reset();
        ui.ShowTitle();
        playerHeight = 0f;
        if (notFirst)
            StartGameplay();
    }
    
    void Update()
    {
        // DEV
        if (Input.GetKeyDown(KeyCode.R))
            RestartGameplay();
        if (Input.GetKeyDown(KeyCode.C))
            PlayerPrefs.DeleteAll();

        float inputX = input.GetInputDirection().x;
        
        var isStartingInput = !started && inputX != 0f;
        if (isStartingInput)
        {
            started = true;
            ui.ShowIntro(StartGameplay);
        }
        
        player.SetMoveX(inputX);

        var playerY = player.transform.position.y;
        
        var isCurrentHighestY = playerY > playerHeight;
        if (isCurrentHighestY)
        {
            playerHeight = playerY;
            score.SetScoreByHeight(playerHeight);
        }
        
        var isFell = playerY < playerHeight - failHeight;
        if (isFell)
            FailGameplay();
    }

    private void FailGameplay()
    {
        ui.failScreen.Show();
        player.Hide();
    }

    private void StartGameplay()
    {
        ui.ShowGameplay();
        player.StartJumping();
    }
}
