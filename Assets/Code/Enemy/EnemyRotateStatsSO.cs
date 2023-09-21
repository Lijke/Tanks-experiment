using UnityEngine;

[CreateAssetMenu(fileName ="EnemyRotateStatsSO" )]
public class EnemyRotateStatsSO : ScriptableObject{
    public float rotateInterval;
    public Vector2 rotateValue;

    public float GetRotationValue(){
        return Random.Range(rotateValue.x, rotateValue.y);
    }
}