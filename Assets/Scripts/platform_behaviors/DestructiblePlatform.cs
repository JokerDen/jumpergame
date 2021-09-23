
    using UnityEngine;

    public class DestructiblePlatform : PlatformBehavior
    {
        public ParticleSystem destroyFX;
        
        protected override void HandlePlayerTouch(PlayerCharacter player)
        {
            base.HandlePlayerTouch(player);
            
            destroyFX.transform.SetParent(null);
            destroyFX.gameObject.SetActive(true);
            
            Destroy(gameObject);
        }
    }