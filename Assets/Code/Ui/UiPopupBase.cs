using System.Collections.Generic;
using UnityEngine;

public class UiPopupBase : MonoBehaviour, IPopup{

    public void Init(){
        
    }

    public void Open(){
        SetActive(true);
    }

    public void Close(){
        SetActive(false);
    }
    
    private void SetActive(bool isActive){
        gameObject.SetActive(isActive);
    }

 

    public void Dispoe(){
        
    }
}