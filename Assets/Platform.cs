using UnityEngine;

public class Platform : MonoBehaviour
{
    public float amplitudeX;

    private void Start()
    {
        var pos = transform.position;
        pos.x += Random.Range(-amplitudeX, amplitudeX);
        transform.position = pos;
    }
}
