using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevel : MonoBehaviour
{
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public float spawnHeightOffset;
    
    private float lastSpawnPos;
    
    [Serializable]
    public struct PlatformGenParams
    {
        public Platform prefab;
        public float minHeight;
        public float maxHeight;
        public float randomWeight;
    }
    public PlatformGenParams[] platforms;

    private List<Platform> spawned = new List<Platform>();

    private List<PlatformGenParams> possibleCache = new List<PlatformGenParams>();

    private void Update()
    {
        var pH = GameManager.current.PlayerHeight;
        
        while (lastSpawnPos - spawnHeightOffset < pH)
        // if (lastSpawnPos - spawnHeightOffset < pH)  // one per frame but guarantee no recursion
        {
            lastSpawnPos += Random.Range(minSpawnInterval, maxSpawnInterval);
            Spawn(lastSpawnPos);
        }
    }

    private void Spawn(float posY)
    {
        possibleCache.Clear();
        float totalWeight = 0f;
        foreach (var platform in platforms)
            if (posY >= platform.minHeight && posY < platform.maxHeight)
            {
                possibleCache.Add(platform);
                totalWeight += platform.randomWeight;
            }
        
        var chance = Random.value * totalWeight;
        
        totalWeight = 0;
        for (int i = 0; i < possibleCache.Count; i++)
        {
            var genParams = possibleCache[i];
            totalWeight += genParams.randomWeight;
            if (chance <= totalWeight)
            {
                var pos = Vector3.up * posY;
                spawned.Add(Instantiate(genParams.prefab, pos, Quaternion.identity, transform));
                return;
            }
        }
    }

    public void Reset()
    {
        foreach (var item in spawned)
            Destroy(item.gameObject);
        spawned.Clear();
        lastSpawnPos = 0f;
    }

    public void RemovePlatform(Platform platform)
    {
        if (!spawned.Contains(platform)) return;

        spawned.Remove(platform);
        Destroy(platform.gameObject);
    }
}
