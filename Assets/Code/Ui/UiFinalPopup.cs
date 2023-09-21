using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFinalPopup : UiPopupBase{
    [SerializeField] private UiButton uiButton;
    [SerializeField] private UiStartPane uiStartPane;
    private void Awake(){
        uiButton.Init();
        uiButton.buttonClickedEvent.AddListener(OpenMainMenuPane);
    }



    private void ShowPopup(){
        UiManager.Instance.Open(this);
    }

    private void OpenMainMenuPane(){
        UiManager.Instance.Open(uiStartPane);
    }
}
