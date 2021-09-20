public class JumpingPlatform : PlatformBehavior
{
    public float jumpForce;
    
    protected override void HandlePlayerTouch(PlayerCharacter player)
    {
        base.HandlePlayerTouch(player);

        player.Jump(jumpForce);
    }
}