using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform model;
    
    [HideInInspector]
    public PlayerEvent onTouch = new PlayerEvent();
    
    [Header("Positioning")]
    public float amplitudeX;
    public Vector3 movingSpeed;
    private int movingDirection;
    
    private void Start()
    {
        var pos = transform.position;
        pos.x += Random.Range(-amplitudeX, amplitudeX);
        transform.position = pos;

        movingDirection = Random.value > .5f ? 1 : -1;
    }

    private void Update()
    {
        var pos = transform.position;
        
        // if (movingSpeed != 0f)
        if (movingSpeed.magnitude > 0f)
            // pos.x += movingSpeed * movingDirection * Time.deltaTime;
            pos += movingDirection * Time.deltaTime * movingSpeed;

        // handle platform outside amplitude
        while (pos.x > amplitudeX || pos.x < -amplitudeX) 
        {
            movingDirection *= -1;
            if (pos.x > amplitudeX)
                pos.x = amplitudeX - (pos.x - amplitudeX);
            if (pos.x < -amplitudeX)
                pos.x = -amplitudeX - (pos.x + amplitudeX);
        }
        transform.position = pos;

        if (pos.y < GameManager.current.FailHeight)
            GameManager.current.level.RemovePlatform(this);
    }
}
