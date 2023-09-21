using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour{
     [SerializeField] private ObjectPool spawner;
     [SerializeField] private BulletObjectPool _bulletObjectPool;
     [SerializeField] private FinishGameController finishGameController;
     [SerializeField] Camera _camera;
    public static GameManager Instance{ get; private set; }

    private void Awake(){
        Instance = this;
        GameEvents.onGameplayerStarted += StartGameplay;
        GameEvents.onFinishGame += DestroyAllEnemies;
    }

    private void OnDestroy(){
        GameEvents.onGameplayerStarted -= StartGameplay;
        GameEvents.onFinishGame -= DestroyAllEnemies;
    }

    private void DestroyAllEnemies(){
        spawner.DestroyAllEnemy();
    }

    private void StartGameplay(int entityCount){
        SpawnEnemies(entityCount);
        SpawnBullets();
        InitFinishGameController(entityCount);
        _camera.orthographicSize = entityCount / 2;
    }

    private void InitFinishGameController(int entityCount){
        finishGameController.Init(entityCount);
    }

    private void SpawnEnemies(int entityCount){
        spawner.InitializeObjectPool(entityCount);
    }

    private void SpawnBullets(){
        _bulletObjectPool.InitializeObjectPool(300);
    }
}
