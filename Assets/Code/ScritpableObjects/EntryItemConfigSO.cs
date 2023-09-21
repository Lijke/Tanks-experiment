using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntryItemConfigSO")]
public class EntryItemConfigSO : ScriptableObject{
    public Sprite normalSprite;
    public Sprite selectedSprite;

    public int itemsToSpawn;
}