using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour{
    public GameObject prefabToPool;
    public int poolSize = 50;
    public bool isActiveAfterSpawn;

    protected List<PoolableObject> pooledObjects = new List<PoolableObject>();
    [SerializeField] private SpawnerSettingsSO spawnerSettingsSo;
    
   public void InitializeObjectPool(int entityCount){
       poolSize = entityCount;
        for (int i = 0; i < entityCount; i++){
            GameObject obj = Instantiate(prefabToPool);
            obj.SetActive(false);

            PoolableObject poolableObject = obj.GetComponent<PoolableObject>();
            if (poolableObject != null){
                poolableObject.Initialize(GetRandomSpawnPosition(poolableObject), isActiveAfterSpawn );
            }

            pooledObjects.Add(poolableObject);
        }
    }

    public (PoolableObject pooledObject,Vector2 positionToSpawn) GetPooledObject(){
 
        // Search for an inactive object in the pool and return it
        foreach (PoolableObject poolObject in pooledObjects){
            if (!poolObject.gameObject.activeInHierarchy){
                poolObject.gameObject.SetActive(true);
                return (poolObject, GetRandomSpawnPosition(poolObject));
            }
        }
        
        return (null, Vector2.zero);
    }
    
    
    
    public virtual Vector2 GetRandomSpawnPosition(PoolableObject poolObjectGameObject){
        Vector2 randomPosition;
        bool positionIsValid = false; 

        do{
            var poolRange = spawnerSettingsSo.GetSpawnRange(poolSize);
            randomPosition = new Vector2(Random.Range(-poolRange.x, poolRange.x), Random.Range(-poolRange.y, poolRange.y)); // Adjust the range as needed
            positionIsValid = IsPositionValid(randomPosition, poolObjectGameObject.gameObject);
        } while (!positionIsValid);

        return randomPosition;
    }

    bool IsPositionValid(Vector2 position, GameObject poolObjectGameObject){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 2);

        foreach (var collider in colliders){
            if (collider.gameObject != poolObjectGameObject){
                return false;
            }
        }

        return true;
    }

    public void DestroyAllEnemy(){
        foreach (var poolableObject in pooledObjects){
            Destroy(poolableObject.gameObject);
        }

        pooledObjects = new List<PoolableObject>();
    }
}