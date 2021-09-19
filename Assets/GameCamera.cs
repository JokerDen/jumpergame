using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform followTarget;

    public float lerpSmoothing;
    
    private void LateUpdate()
    {
        if (followTarget != null)
        {
            var pos = transform.position;
            var lerpedPos = Vector3.Lerp(pos, followTarget.position, lerpSmoothing * Time.deltaTime);
            if (lerpedPos.y > pos.y)
                pos.y = lerpedPos.y;
            transform.position = pos;
        }
    }
}
