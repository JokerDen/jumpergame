public class Booster : PlatformBehavior
{
    public float boostForce;
    public float boostDuration;
    
    protected override void HandlePlayerTouch(PlayerCharacter player)
    {
        base.HandlePlayerTouch(player);

        player.SetBoost(boostForce, boostDuration);
    }
}
