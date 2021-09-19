using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public PlayerCharacter player;
    public PlayerInput input;

    public GameLevel level;

    private bool started;

    public float playerHeight;

    public static GameManager current;

    private void Awake()
    {
        current = this;
        
        Application.targetFrameRate = 60;
        // Time.fixedDeltaTime = 0.02f;
        // Time.fixedDeltaTime = 1f / 30f;
    }
    
    public void RestartGameplay()
    {
        
    }
    
    void Update()
    {
        // float inputX = input.keyInput.x + input.dragInput.x;
        float inputX = input.GetInputDirection().x;
        if (!started && inputX != 0f)
        {
            started = true;
            player.isGravityEnabled = true;
        }

        var moveInput = Mathf.Clamp(inputX, -1f, 1f);
        player.SetMove(moveInput * Time.deltaTime);
        // player.SetMove(moveInput);

        var playerY = player.transform.position.y;
        if (playerY > playerHeight)
            playerHeight = playerY;
    }
}
