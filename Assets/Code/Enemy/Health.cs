using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable{
   void TakeDamage(int damage);
}
public class Health : MonoBehaviour, IDamagable{
   public int maxHealth = 3;
   private int currentHealth =3;
   public Action onDamageDeal;
   public Action onDeath;

   private void Awake(){
      maxHealth = currentHealth;
   }

   public void TakeDamage(int damage){
      currentHealth -= damage;
      if (currentHealth > 0){
         onDamageDeal?.Invoke();
      }
      else{
         onDeath?.Invoke();
         GameEvents.OnEnemyDeath();
      }
   }
}
