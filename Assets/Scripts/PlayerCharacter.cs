using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveXSpeed;
    public float amplitudeX;

    private Vector3 currentSpeed;
    private bool isGravityEnabled;

    [Header("Injections")]
    public Vector3 jumpImpulse;
    public Animator anim;
    public SphereCaster legs;

    // private void FixedUpdate()
    private void Update()
    {
        if (isGravityEnabled)
            currentSpeed += Physics.gravity * Time.deltaTime;

        var step = currentSpeed * Time.deltaTime;
        if (currentSpeed.y < 0f && legs.Cast(step))
        {
            Jump();
            return;
        }
        
        var pos = transform.position;
        pos += step;
        pos.x = Mathf.Clamp(pos.x, -amplitudeX, amplitudeX);
        transform.position = pos;
    }

    private void Jump()
    {
        anim.ResetTrigger("Jump");
        anim.SetTrigger("Jump");
        
        currentSpeed = jumpImpulse;
    }

    public void SetMove(float moveInput)
    {
        if (!isGravityEnabled) return;
        // currentSpeed.x = Mathf.Clamp(moveInput * moveXSpeed, -amplitudeX, amplitudeX);
        
        var pos = transform.position;
        pos.x += moveInput * moveXSpeed;
        pos.x = Mathf.Clamp(pos.x, -amplitudeX, amplitudeX);
        transform.position = pos;
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
}
