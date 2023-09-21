using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    public ShootingStatsSO shootingStatsSo;
    private bool canShoot;
    public BulletLauncher bulletLauncher;


    private void Start(){
        canShoot = true;
    }

    private void Update(){
        if (canShoot){
            canShoot = false;
            bulletLauncher.Launch(this);
            Invoke("PrepareShoot", shootingStatsSo.bulletTimeBetweenShoots);
        }
    }

    public void PrepareShoot(){
        canShoot = true;
    }
}