using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UiFinalPopup : UiPopupBase{
    public override PopupType popupType{
        get{
            var finishMenu = PopupType.FinishMenu;
            return finishMenu;
        }
        set{ }
    }
    [SerializeField] private UiButton uiButton;
    [FormerlySerializedAs("uiStartPane")] [SerializeField] private MainMenuPane mainMenuPane;
    private void Awake(){
        uiButton.Init();
        uiButton.buttonClickedEvent.AddListener(OpenMainMenuPane);
    }



    private void ShowPopup(){
        UiManager.Instance.Open(this);
    }

    private void OpenMainMenuPane(){
        UiManager.Instance.Open(mainMenuPane);
    }
}
