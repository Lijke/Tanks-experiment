using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IPool{
    
}
public class GenericPool<T> : MonoBehaviour,IPool where T:Component{
  private T prefab;
  private GridGenerator spawnPoint;
  private Stack<T> elements = new Stack<T>();

  public GenericPool(T prefab, GridGenerator spawnPoint){
    this.prefab = prefab;
    this.spawnPoint = spawnPoint;
  }
  
  

  public void SpawnObjects(int entityCount){
    int poolSize = entityCount;
    for (int i = 0; i < poolSize; i++){
      PreapreSingleObject();
    }
  }

  private T PreapreSingleObject(){
    var poolObject = Instantiate(prefab);
    poolObject.gameObject.SetActive(false);
    poolObject.transform.position = spawnPoint.GetRandomSpawnPos();
    elements.Push(poolObject);
    return poolObject;
  }

  public T GetFromPool(){
    return elements.First(x => !x.gameObject.activeInHierarchy);
  }

  public void ReturnToPool(T pooledObject){
    elements.Push(pooledObject);
  }
  
  
  
}
