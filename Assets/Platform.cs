using UnityEngine;

public class Platform : MonoBehaviour
{
    public float amplitudeX;

    public bool destructible;

    public float movingSpeed;
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
        
        if (movingSpeed != 0f)
            pos.x += movingSpeed * movingDirection * Time.deltaTime;

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
    }

    public void HandleTouch()
    {
        if (destructible)
        {
            // todo: create fx, at least tween
            Destroy(gameObject);
        }
    }
}
