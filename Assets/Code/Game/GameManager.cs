using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour{
    [SerializeField] private FinishGameController finishGameController;
     [SerializeField] Camera _camera;
     
    public static GameManager Instance{ get; private set; }

    private GenericPool<PoolableObject> enemiesPool;
    [SerializeField] private PoolableObject enemyPrefab;

    private GenericPool<PoolableObject> bulletPool;
    [SerializeField] private PoolableObject bulletPrefab;

    [SerializeField] private GridGenerator gridGenerator;
    private void Awake(){
        Instance = this;
        SpawnFromPool();
        gridGenerator.GenerateGrid();
        
        GameEvents.onGameplayerStarted += StartGameplay;
        GameEvents.onFinishGame += DestroyAllEnemies;
    }

    private void SpawnFromPool(){
        enemiesPool = new GenericPool<PoolableObject>(enemyPrefab, gridGenerator);
        bulletPool = new GenericPool<PoolableObject>(bulletPrefab, gridGenerator);
    }

    private void OnDestroy(){
        GameEvents.onGameplayerStarted -= StartGameplay;
        GameEvents.onFinishGame -= DestroyAllEnemies;
    }

    private void DestroyAllEnemies(){
       
    }

    private void StartGameplay(int entityCount){
        SpawnEnemies(entityCount);
        InitFinishGameController(entityCount);
        _camera.orthographicSize = entityCount / 2;
    }

    private void InitFinishGameController(int entityCount){
        finishGameController.Init(entityCount);
    }

    private void SpawnEnemies(int entityCount){
        enemiesPool.SpawnObjects(entityCount);
        bulletPool.SpawnObjects(entityCount);
    }
    
}
