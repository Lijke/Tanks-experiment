using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour{
    [SerializeField] private EnemyRotateStatsSO enemyRotateStatsSo;
    [SerializeField] private HitEnemyController hitEnemyController;

    private void Awake(){
        InvokeRepeating("Rotate",0, enemyRotateStatsSo.rotateInterval);
    }

    private void OnEnable(){
        InvokeRepeating("Rotate",0, enemyRotateStatsSo.rotateInterval);
    }

    private void OnDisable(){
        CancelInvoke("Rotate");
    }

    void Rotate(){
        if (gameObject.activeInHierarchy && !hitEnemyController.isActive){
            return;
        }
        var rotationValue = enemyRotateStatsSo.GetRotationValue();
        transform.Rotate(Vector3.forward * rotationValue);
    }
}