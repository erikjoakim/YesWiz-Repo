using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EquipableItem : ScriptableObject {

    [Header("Equipable Item")]
    public Sprite inventoryPicture;
    public Transform gripTransform;
    public GameObject weaponPrefab;
    
}
