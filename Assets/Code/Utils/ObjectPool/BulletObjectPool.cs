using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : ObjectPool{
   public static BulletObjectPool Instance;

   private void Awake(){
      Instance = this;
   }

   public PoolableObject GetBullet(){
      foreach (PoolableObject poolObject in pooledObjects){
         if (!poolObject.gameObject.activeInHierarchy){
            return poolObject;
         }
      }
      
      return null;
   }


   public override Vector2 GetRandomSpawnPosition(PoolableObject poolObjectGameObject){
      return new Vector2(1000, 1000);
   }
}
