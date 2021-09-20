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
        // float inputX = input.keyInput.x + input.dragInput.x;
        float inputX = input.GetInputDirection().x;
        if (!started && inputX != 0f)
        {
            started = true;
            player.StartJumping();
        }

        var moveInput = Mathf.Clamp(inputX, -1f, 1f);
        player.SetMove(moveInput * Time.deltaTime);
        // player.SetMove(moveInput);

        var playerY = player.transform.position.y;
        if (playerY > playerHeight)
            playerHeight = playerY;
        if (playerY < playerHeight - failHeight)
        {
            ui.failScreen.Show();
            player.Hide();
        }
    }
}
