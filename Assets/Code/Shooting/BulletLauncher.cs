using System;
using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private HitEnemyController hitEnemyController;
    public void Launch(Weapon weapon){
        if (!hitEnemyController.isActive){
            return;
        }
        var bullet = BulletObjectPool.Instance.GetBullet();
        if (bullet == null){
            return;
        }
        bullet.transform.position = shootingPoint.position;
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Init(weapon, shootingPoint);
    }

  
}
