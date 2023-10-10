using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HitEnemyController : MonoBehaviour{
    public Health health;
    [SerializeField] private SpriteRenderer spriteRendererBody;
    [SerializeField] private SpriteRenderer spriteRendererRiffle;
    [SerializeField] private BoxCollider2D boxCollider2D;
    public bool isActive = true;
    private void Awake(){
        health.onDamageDeal += Reborn;
        health.onDeath += Death;
    }

    private void OnDestroy(){
        health.onDamageDeal -= Reborn;
        health.onDeath -= Death;
    }

    private void Death(){
        ReturnToPool();
    }

    private void ReturnToPool(){
        gameObject.SetActive(false);
        GameManager.Instance.enemiesPool.ReturnToPool(GetComponent<PoolableObject>());
    }

    private void Reborn(){
        TurnOffLogic();
        Invoke("ComeBackFight", 2f);
    }

    private void TurnOffLogic(){
        boxCollider2D.enabled = false;
        gameObject.SetActive(false);
    }

    void ComeBackFight(){
        isActive = true;
        boxCollider2D.enabled = true;
        gameObject.SetActive(true);
    }
}
