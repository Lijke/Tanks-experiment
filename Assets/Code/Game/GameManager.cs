using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour{
    [SerializeField] private FinishGameController finishGameController;
     [SerializeField] Camera _camera;
     
    public static GameManager Instance{ get; private set; }

    [HideInInspector] public GenericPool<PoolableObject> enemiesPool;
    [SerializeField] private PoolableObject enemyPrefab;

    [HideInInspector] public GenericPool<PoolableObject> bulletPool;
    [SerializeField] private PoolableObject bulletPrefab;

    [SerializeField] private GridGenerator gridGenerator;
    private void Awake(){
        Instance = this;
        GameEvents.onGameplayerStarted += StartGameplay;
        GameEvents.onFinishGame += DestroyAllEnemies;
    }

    private void SetupCamera(int entityCount){
        _camera.orthographicSize = entityCount / 2;
    }

    private void SpawnFromPool(){
        enemiesPool = new GenericPool<PoolableObject>(enemyPrefab);
        bulletPool = new GenericPool<PoolableObject>(bulletPrefab);
    }

    private void OnDestroy(){
        GameEvents.onGameplayerStarted -= StartGameplay;
        GameEvents.onFinishGame -= DestroyAllEnemies;
    }

    private void DestroyAllEnemies(){
        enemiesPool.DisableLastEnemy();
    }

    private void StartGameplay(int entityCount){
        SetupCamera(entityCount);
        SpawnEnemies(entityCount);
        InitFinishGameController(entityCount);
    }

    private void InitFinishGameController(int entityCount){
        finishGameController.Init(entityCount);
    }

    private void SpawnEnemies(int entityCount){
        gridGenerator.GenerateGrid();
        SpawnFromPool();
        enemiesPool.SpawnObjects(entityCount);
        bulletPool.SpawnObjects(entityCount*5);
    }
    
}
