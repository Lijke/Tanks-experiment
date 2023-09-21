using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerSettingsSO")]
public class SpawnerSettingsSO : ScriptableObject{
    public float minDistance = 2.0f;
    public float minXOffstet = -10f;
    public float maxXOffset = 10f;
    public float minYOffset = -10f;
    public float maxYOffset = 10f;


    public Vector2 GetSpawnRange(int entityToSpawnCount){
        if (entityToSpawnCount == 50){
            return new Vector2(-20, 20);
        } 
        if (entityToSpawnCount == 100){
            return new Vector2(-40, 40);
        }

        if (entityToSpawnCount == 250){
            return new Vector2(-100, 100);
        }

        if (entityToSpawnCount == 500){
            return new Vector2(-250, 250);
        }

        return Vector2.zero;
    }
}