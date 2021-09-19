using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public Vector3 jumpImpulse;
    public Animator anim;
    public SphereCaster legs;
    
    public Vector3 currentSpeed;

    public bool isGravityEnabled;

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

        transform.position += step;
    }

    private void Jump()
    {
        anim.ResetTrigger("Jump");
        anim.SetTrigger("Jump");
        
        currentSpeed = jumpImpulse;
    }
}
