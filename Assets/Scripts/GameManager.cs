using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerCharacter player;
    public PlayerInput input;

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
        started = false;
        player.Reset();
        cam.Reset();
        level.Reset();
        ui.ShowTitle();
        playerHeight = 0f;
    }
    
    void Update()
    {
        float inputX = input.GetInputDirection().x;
        
        var isStartingInput = !started && inputX != 0f;
        if (isStartingInput)
        {
            started = true;
            ui.ShowStartGameplay(StartGameplay);
        }
        
        player.SetMoveX(inputX);

        var playerY = player.transform.position.y;
        
        var isCurrentHighestY = playerY > playerHeight;
        if (isCurrentHighestY)
            playerHeight = playerY;
        
        var isFell = playerY < playerHeight - failHeight;
        if (isFell)
        {
            ui.failScreen.Show();
            player.Hide();
        }
    }

    private void StartGameplay()
    {
        player.StartJumping();
    }
}
