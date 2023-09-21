using UnityEngine;

[CreateAssetMenu(fileName = "ShootingStatsSO", menuName = "ScriptableObjects/ShootingStatsSO")]
public class ShootingStatsSO : ScriptableObject{
    public int bulletDamage;
    public float bulletTimeBetweenShoots;
    public float bulletSpeed;
}