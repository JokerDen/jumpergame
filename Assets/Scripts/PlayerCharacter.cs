using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : MonoBehaviour
{
    public float moveXSpeed;
    public float moveRotation;
    public float amplitudeX;

    public ParticleSystem boost;

    private Vector3 currentSpeed;
    private Vector3 boostSpeed;
    private float boostDuration;
    private bool isGravityEnabled;

    [Header("Injections")]
    public Animator anim;

    public SphereCaster legs;

    // private void FixedUpdate()
    private void Update()
    {
        if (boostDuration > 0f)
        {
            currentSpeed = boostSpeed;
            boostDuration -= Time.deltaTime;
        }
        else if (isGravityEnabled)
            currentSpeed += Physics.gravity * Time.deltaTime;

        var step = currentSpeed * Time.deltaTime;
        if (currentSpeed.y < 0f)
        {
            var col = legs.Cast(step);
            if (col != null)
            {
                // GetComponent is not effective in Runtime on Update but in current game requirements (rare touches) is ok
                var touchedPlatform = col.GetComponent<Platform>();
                if (touchedPlatform != null)
                    touchedPlatform.onTouch.Invoke(this);
                return;
            }
        }

        var pos = transform.position;
        pos += step;
        pos.x = Mathf.Clamp(pos.x, -amplitudeX, amplitudeX);
        transform.position = pos;

        var angles = transform.eulerAngles;
        var angleLerp = Mathf.InverseLerp(-moveXSpeed, moveXSpeed, currentSpeed.x);
        angles.y = -Mathf.Lerp(-moveRotation, moveRotation, angleLerp);
        transform.eulerAngles = angles;
    }

    public void Jump(float force)
    {
        anim.ResetTrigger("Jump");
        anim.SetTrigger("Jump");

        currentSpeed = Vector3.up * force;
    }

    public void SetMove(float moveInput)
    {
        if (!isGravityEnabled) return;
        currentSpeed.x = Mathf.Clamp(moveInput * moveXSpeed, -moveXSpeed, moveXSpeed);

        // moveXSpeed = moveInput * moveXSpeed;
        /*var pos = transform.position;
        pos.x += moveInput * moveXSpeed;
        pos.x = Mathf.Clamp(pos.x, -amplitudeX, amplitudeX);
        transform.position = pos;*/
    }

    public void Hide()
    {
        anim.Rebind();
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        currentSpeed = Vector3.zero;
        isGravityEnabled = false;
        gameObject.SetActive(true);
    }

    public void StartJumping()
    {
        isGravityEnabled = true;
    }

    public void SetBoost(float boostForce, float duration)
    {
        boostSpeed = Vector3.up * boostForce;
        boostDuration = duration;
    }
}

[System.Serializable]
public class PlayerEvent : UnityEvent<PlayerCharacter>
{
}