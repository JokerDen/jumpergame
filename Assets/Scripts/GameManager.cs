using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public PlayerCharacter player;
    public PlayerInput input;
    public ScoreManager score;
    public GameLevel level;
    public GameUI ui;
    public GameCamera cam;
    
    private bool started;
    private bool failed;
    private float playerHeight;
    public float PlayerHeight => playerHeight;
    [SerializeField] bool autoStart;
    [FormerlySerializedAs("failHeight")] [SerializeField] float failHeightOffset;
    public float FailHeight => playerHeight - failHeightOffset;
    
    public static GameManager current;

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
        failed = false;
        player.Reset();
        score.Reset();
        cam.Reset();
        level.Reset();
        ui.ShowTitle();
        playerHeight = 0f;
    }
    
    void Update()
    {
        // DEV
        if (Input.GetKeyDown(KeyCode.R))
            RestartGameplay();
        if (Input.GetKeyDown(KeyCode.C))
            PlayerPrefs.DeleteAll();

        float inputX = input.GetInputDirection().x;
        
        var startIntro = !started && (inputX != 0f || autoStart);
        if (startIntro)
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
        
        var isFell = !failed && playerY < FailHeight;
        if (isFell)
        {
            failed = true;
            // autoStart = true;
            FailGameplay();
        }
    }

    private void FailGameplay()
    {
        ui.ShowFail();
        player.Hide();
    }

    private void StartGameplay()
    {
        ui.ShowGameplay();
        player.StartJumping();
    }
}
