using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButton : MonoBehaviour{
   [SerializeField] private Button button;
   [SerializeField] private GameObject extraIcon;
   public Button.ButtonClickedEvent buttonClickedEvent;
   [SerializeField] private bool isActive = false;
   private void OnValidate(){
      button = GetComponent<Button>();
   }
   

   public void SetupSprite(Sprite newSprite){
      button.image.sprite = newSprite;
   }

   public void EnableExtraIcon(bool isActive){
      if (extraIcon == null){
         return;
      }
      extraIcon.SetActive(isActive);
   }
   

   public void Init(){
      buttonClickedEvent = button.onClick;
   }

   public void SetupActiveState(bool isActive){
      this.isActive = isActive;
   }

   public bool IsActive() => isActive;
}
