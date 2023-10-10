using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class UiEntryItem : UiItemBase{
    public EntryItemConfigSO entryItemConfigSo;
    public Animator animator;
    [FormerlySerializedAs("UiIMage")] public UiImage uiImage;

    public override void OnPointerEnter(PointerEventData eventData){
        ResetAnimator();
        SetAnimator("ScaleUp",true);
    }
    
    
    public override void OnPointerExit(PointerEventData eventData){
        ResetAnimator();
        SetAnimator("ScaleDown", true);

    }
    private void ResetAnimator(){
        SetAnimator("ScaleUp", false);
        SetAnimator("ScaleDown", false);

    }

    void SetAnimator(string parameter, bool state){
        animator.SetBool(parameter,state);
    }

    public override void OnPointerClick(PointerEventData eventData){
        base.OnPointerClick(eventData);
        animator.SetBool("ScaleUp", true);
        ResetAnimator();
        RaiseEvent();
        SetSelection(true);
    }

    private void RaiseEvent(){
        GameEvents.OnItemClicked(this);
    }
    
    public override void SetSelection(bool isSelected){
        if (isSelected){
            uiImage.ChangeSprite(entryItemConfigSo.selectedSprite);
        }
        else{
            uiImage.ChangeSprite(entryItemConfigSo.normalSprite);
        }
    }
}