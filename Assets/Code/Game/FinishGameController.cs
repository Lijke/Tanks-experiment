using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameController : MonoBehaviour{
    private float spawnedEnemy;

    private void Awake(){
        GameEvents.onEnemyDeath += CountDeath;
    }
    
    private void OnDestroy(){
        GameEvents.onEnemyDeath -= CountDeath;
    }
    
    private void CountDeath(){
        spawnedEnemy--;
        if (spawnedEnemy > 1 ){
            return;
        }
        
        GameEvents.FinishGame();
    }


    public void Init(int entityCount){
        spawnedEnemy = entityCount;
    }
}
