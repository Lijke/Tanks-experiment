using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UiManager : MonoBehaviour, IPopupManager{
    public static UiManager Instance { get; private set; }
    private List<UiPopupBase> popupList = new List<UiPopupBase>();
    private UiPopupBase openPopup;
    [SerializeField] private UiFinalPopup finalPopup;
    private void Awake(){
        Instance = this;
        RegisterPopUp();
        FindStartingPopup();
        GameEvents.onFinishGame += ShowFinalPopup;
    }

    private void ShowFinalPopup(){
        Open(finalPopup);
    }

    private void OnDestroy(){
        GameEvents.onFinishGame -= ShowFinalPopup;
    }

    private void FindStartingPopup(){
        var startingPopup = popupList.First(x => x is UiStartPane);
        openPopup = startingPopup;
        Open(openPopup);
    }

    public void RegisterPopUp(){
        GetComponentsInChildren(true, popupList);
    }

    public void Open(UiPopupBase uiPopupBase){
        if (openPopup != null){
            Close(openPopup);
        }

        openPopup = uiPopupBase;
        openPopup.Init();
        openPopup.Open();
    }

    public void CloseCurrentPopup(){
        openPopup.Close();
    }

    public void Close(UiPopupBase uiPopupBase){
        uiPopupBase.Dispoe();
        uiPopupBase.Close();
    }
    

}