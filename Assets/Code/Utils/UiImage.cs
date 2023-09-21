using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiImage : MonoBehaviour{
   [SerializeField] private Image image;

   private void OnValidate(){
      image = GetComponent<Image>();
   }

   public void ChangeSprite(Sprite sprite){
      image.sprite = sprite;
   }
}
