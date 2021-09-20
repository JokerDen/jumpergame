using UnityEngine;
using UnityEngine.Serialization;

public class Platform : MonoBehaviour
{
    public float amplitudeX;

    public bool destructible;

    private void Start()
    {
        var pos = transform.position;
        pos.x += Random.Range(-amplitudeX, amplitudeX);
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
