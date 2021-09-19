using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveXSpeed;
    public float amplitudeX;

    public bool isGravityEnabled;
    
    private Vector3 currentSpeed;

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
        // currentSpeed.x = Mathf.Clamp(moveInput * moveXSpeed, -amplitudeX, amplitudeX);
        
        var pos = transform.position;
        pos.x += moveInput * moveXSpeed;
        pos.x = Mathf.Clamp(pos.x, -amplitudeX, amplitudeX);
        transform.position = pos;
    }
    
}
