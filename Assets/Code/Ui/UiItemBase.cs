using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class UiItemBase : MonoBehaviour, IUiItem, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler{

    
    public virtual void OnPointerEnter(PointerEventData eventData){ }

    public virtual void OnPointerClick(PointerEventData eventData){ }

    public virtual void OnPointerExit(PointerEventData eventData){ }
    public virtual void SetSelection(bool isSelected){
        
    }
}