using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    private Weapon weapon;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private PoolableObject poolableObject;

    private void Awake(){
        gameObject.gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            Health health;
            if (other.gameObject.TryGetComponent<Health>(out health)){
                health.TakeDamage(weapon.shootingStatsSo.bulletDamage);
            }
        }

        if (other.gameObject.CompareTag("Bullet")){
            DisableObject();
        }
        DisableObject();
    }

    
    public void Init(Weapon weapon, Transform shootingPoint){
        this.weapon = weapon;
        EnableObject();
        AddForce(shootingPoint);
    }

    private void AddForce(Transform shootingPoint){
        rb.AddForce(shootingPoint.up * weapon.shootingStatsSo.bulletSpeed, ForceMode2D.Impulse);
    }

    private void EnableObject(){
        gameObject.SetActive(true);
        Invoke("DisableObject", 5f);
    }

    private void DisableObject(){
        gameObject.SetActive(false);
        GameManager.Instance.bulletPool.ReturnToPool(poolableObject);
    }
}
