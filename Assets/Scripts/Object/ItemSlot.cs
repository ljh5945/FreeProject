using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image thumbnail;
    [SerializeField] private GameObject EquipObject;

    private Item item;

    public void Init(Item item)
    {
        this.item = item;

        thumbnail.sprite = item.Data.ItemSprite;
        EquipObject.SetActive(item.IsEquipped);
    }

    public void OnClickItem()
    {
        item.IsEquipped = !item.IsEquipped;
        EquipObject.SetActive(item.IsEquipped);
    }
}
