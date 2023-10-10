using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolable{
    public void Initialize(Vector2 randomSpawnPosition, bool isActiveAfterSpawn){
        SetupSpawnPosition(randomSpawnPosition);
        ActivateGameObject(isActiveAfterSpawn);
    }

    public void Reset(){
        
    }

    private void ActivateGameObject(bool isActiveAfterSpawn){
        gameObject.SetActive(isActiveAfterSpawn);
    }

    private void SetupSpawnPosition(Vector2 randomSpawnPosition){
        transform.position = randomSpawnPosition;
    }

}