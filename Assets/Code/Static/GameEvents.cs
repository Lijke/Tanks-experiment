using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents{
    public static Action<UiEntryItem> onItemClicked;

    public static void OnItemClicked(UiEntryItem uiItemBase){
        onItemClicked?.Invoke(uiItemBase);
    }

    public static Action<int> onGameplayerStarted;

    public static void OnGameplayStarted(int numbersOfEntity){
        onGameplayerStarted?.Invoke(numbersOfEntity);
    }

    public static Action onEnemyDeath;

    public static void OnEnemyDeath(){
        onEnemyDeath?.Invoke();
    }

    public static Action onFinishGame;
    public static void FinishGame(){
        onFinishGame?.Invoke();
    }
}
