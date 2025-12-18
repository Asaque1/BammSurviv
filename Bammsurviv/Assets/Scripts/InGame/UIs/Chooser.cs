using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chooser : MonoBehaviour, IPointerClickHandler
{
    [Header("objects")]
    [SerializeField] public TMPro.TextMeshProUGUI itemName;
    [SerializeField] public TMPro.TextMeshProUGUI itemDesc;
    [SerializeField] public Image itemSprite;
    public static event Action<int> OnItemChosen;
    public int itemChosenIndex;
    public void GetItem(ChooseM.Items seledItem)
    {
        itemName.text = seledItem.itemName;
        itemDesc.text = seledItem.itemDesc;
        itemSprite.sprite = seledItem.itemSprite;
        itemChosenIndex = seledItem.itemIndex;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemChosen?.Invoke(itemChosenIndex);
    }

}
