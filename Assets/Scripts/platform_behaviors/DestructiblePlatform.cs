
    public class DestructiblePlatform : PlatformBehavior
    {
        protected override void HandlePlayerTouch(PlayerCharacter player)
        {
            base.HandlePlayerTouch(player);
            Destroy(gameObject);
        }
    }