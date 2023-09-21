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
        TurnOffLogic();
    }

    private void Reborn(){
        TurnOffLogic();
        Invoke("ComeBackFight", 2f);
    }

    private void TurnOffLogic(){
        var color = new Color(0, 0, 0,0 );
        spriteRendererBody.color = color;
        spriteRendererRiffle.color = color;
        boxCollider2D.enabled = false;
        isActive = false;
    }

    void ComeBackFight(){
        isActive = true;
        var fullColor = new Color(255, 255, 255, 255);
        spriteRendererBody.color = fullColor;
        spriteRendererRiffle.color = fullColor;
        boxCollider2D.enabled = true;
    }
}
