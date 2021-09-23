using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformBehavior : MonoBehaviour
{
    protected Platform platform;
    
    private void Awake()
    {
        platform = GetComponent<Platform>();
        platform.onTouch.AddListener(HandlePlayerTouch);
    }

    protected virtual void HandlePlayerTouch(PlayerCharacter player)
    {
        
    }
}