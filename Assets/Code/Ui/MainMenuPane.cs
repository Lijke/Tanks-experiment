using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPane : UiPopupBase{
    public override PopupType popupType{
        get{
            var finishMenu = PopupType.MainMenu;
            return finishMenu;
        }
        set{ }
    }
    
    private UiEntryItem currentItem;
    [SerializeField] private UiButton uiButton;
    [SerializeField] private ButtonItemConfigSO buttonItemConfigSo;
    private void Start(){
        GameEvents.onItemClicked += ChangeCurrentItem;
        uiButton.Init();
        uiButton.buttonClickedEvent.AddListener(StartGame);
        
    }
    
    private void OnDestroy(){
        GameEvents.onItemClicked -= ChangeCurrentItem;
        uiButton.buttonClickedEvent.RemoveListener(StartGame);
    }

    private void OnDisable(){
        currentItem.SetSelection(false);
        uiButton.EnableExtraIcon(false);
        uiButton.SetupActiveState(false);
    }

    private void StartGame(){
        if (!uiButton.IsActive()){
            return;
        }
        DisablePopup();
        GameEvents.OnGameplayStarted(currentItem.entryItemConfigSo.itemsToSpawn);
    }

    private void DisablePopup(){
        UiManager.Instance.CloseCurrentPopup();
    }

    private void ChangeCurrentItem(UiEntryItem obj){
        if (currentItem != null){
            currentItem.SetSelection(false);
        }
        currentItem = obj;
        uiButton.SetupActiveState(true);
        uiButton.SetupSprite(buttonItemConfigSo.selectedSprite);
        uiButton.EnableExtraIcon(true);
    }


}
