using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    private Weapon weapon;
    [SerializeField] Rigidbody2D rb;
    private void Awake(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            Health health;
            if (other.gameObject.TryGetComponent<Health>(out health)){
                health.TakeDamage(weapon.shootingStatsSo.bulletDamage);
            }
        }
        DisableObject();
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Enemy")){
            Health health;
            if (other.gameObject.TryGetComponent<Health>(out health)){
                health.TakeDamage(weapon.shootingStatsSo.bulletDamage);
            }
        }
        DisableObject();
    }

    public void Init(Weapon weapon, Transform shootingPoint){
        this.weapon = weapon;
        EnableObject();
        Fly(shootingPoint);
    }

    private void Fly(Transform shootingPoint){
        rb.AddForce(shootingPoint.up * weapon.shootingStatsSo.bulletSpeed, ForceMode2D.Impulse);
    }

    private void EnableObject(){
        gameObject.SetActive(true);
        Invoke("DisableObject", 5f);
    }

    private void DisableObject(){
        gameObject.SetActive(false);
    }
}
