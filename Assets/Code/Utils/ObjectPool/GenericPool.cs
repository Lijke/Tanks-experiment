using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IPool{
    
}
public class GenericPool<T> : MonoBehaviour,IPool where T:Component{
  private T prefab;
  private Stack<T> elements = new Stack<T>();

  public GenericPool(T prefab){
    this.prefab = prefab;
  }
  
  public void SpawnObjects(int entityCount){
    int poolSize = entityCount;
    for (int i = 0; i < poolSize; i++){
      PreapreSingleObject();
    }
  }

  private T PreapreSingleObject(){
    var poolObject = Instantiate(prefab);
    poolObject.transform.position = GridGenerator.Instance.GetRandomSpawnPos();
    elements.Push(poolObject);
    return poolObject;
  }

  public T GetFromPool(){
    var element =  elements.First(x => !x.gameObject.activeInHierarchy);
    if (element == null){
      return PreapreSingleObject();
    }

    return element;
  }

  public void ReturnToPool(T pooledObject){
    elements.Push(pooledObject);
  }


  public void DisableLastEnemy(){
    var enemy = elements.First(x => x.gameObject.activeInHierarchy);
    enemy.gameObject.SetActive(false);
    elements.Push(enemy);
  }
}
