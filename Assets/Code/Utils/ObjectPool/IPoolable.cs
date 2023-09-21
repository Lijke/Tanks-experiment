using UnityEngine;

public interface IPoolable
{
    void Initialize(Vector2 randomSpawnPosition, bool isActiveAfterSpawn);
    void Reset();
}