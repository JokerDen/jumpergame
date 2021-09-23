using DG.Tweening;
using UnityEngine;

public class JumpingPlatform : PlatformBehavior
{
    public float jumpForce;

    public bool useBackShotAnimation;
    
    [SerializeField] float backDuration;
    [SerializeField] Ease backEase;
    
    [SerializeField] float shotDuration;
    [SerializeField] Ease shotEase;

    [SerializeField]
    private Vector3 modelBackLocalPos;
    
    protected override void HandlePlayerTouch(PlayerCharacter player)
    {
        base.HandlePlayerTouch(player);

        player.Jump(jumpForce);

        if (!useBackShotAnimation) return;
        platform.model.DOKill();
        platform.model.DOLocalMove(modelBackLocalPos, backDuration).SetEase(backEase).OnComplete(Shot);
    }

    private void Shot()
    {
        if (platform == null) return;
        platform.model.DOLocalMove(Vector3.zero, shotDuration).SetEase(shotEase);
    }
}