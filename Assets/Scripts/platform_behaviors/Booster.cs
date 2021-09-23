using DG.Tweening;
using UnityEngine;

public class Booster : PlatformBehavior
{
    public float boostForce;
    public float boostDuration;

    public Transform item;
    
    protected override void HandlePlayerTouch(PlayerCharacter player)
    {
        base.HandlePlayerTouch(player);

        player.SetBoost(boostForce, boostDuration);
        item.DOScale(0f, .5f);
    }
}
