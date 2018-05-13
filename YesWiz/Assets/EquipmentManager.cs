using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    Inventory inventory;

    private void Start()
    {
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        currentEquipment = new Equipment[numberOfSlots];
        inventory = Inventory.instance;
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        if (currentEquipment[slotIndex] != null)
        {
            inventory.Add(currentEquipment[slotIndex]);
        }
        if (onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, currentEquipment[slotIndex]);
        }
        currentEquipment[slotIndex]=newItem;
    }

    public void UnEquip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            inventory.Add(currentEquipment[slotIndex]);
            currentEquipment[slotIndex] = null;
        }
        if (onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(null, currentEquipment[slotIndex]);
        }
    }
}
