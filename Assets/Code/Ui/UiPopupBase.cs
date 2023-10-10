using System.Collections.Generic;
using UnityEngine;

public enum PopupType{
    MainMenu = 0,
    FinishMenu = 1
}


public abstract class UiPopupBase : MonoBehaviour, IPopup{
    public abstract PopupType popupType{ get; set; }
    public void Init(){
        
    }

    public virtual void Open(){
        SetActive(true);
    }

    public virtual void Close(){
        SetActive(false);
    }
    
    private void SetActive(bool isActive){
        gameObject.SetActive(isActive);
    }

 

    public virtual void Dispoe(){ }
}