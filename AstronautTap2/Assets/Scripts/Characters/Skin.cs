
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Game/Skin")]
public class Skin : ScriptableObject
{
    public string skinName;
    [HideInInspector]
    public bool isUnlocked = false;
    [HideInInspector]
    public int id;
    public Sprite sprite;
    public int price;
}

