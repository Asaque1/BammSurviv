using System.Collections.Generic;
using UnityEngine;

public class ChooseM : MonoBehaviour
{
    [System.Serializable]
    public class Items
    {
        public int itemLevel;
        public string itemName;
        public string itemDesc;
        public Sprite itemSprite;
        public int itemIndex;
    }

    [Header("Max level that can be choosed")]
    [SerializeField] int levelMax;

    [Header("allItemList")]
    [SerializeField] public List<Items> itemList = new List<Items> { };

    [Header("fallback item for when no item can choose")]
    [SerializeField] private Items fallbackItem;

    [Header("playerData")]
    [SerializeField] public Player_StatData pData;

    private List<Items> selectableList = new List<Items>();

    public void InitialzeSelector()
    {
        selectableList.Clear();
        foreach (Items item in itemList)
        {
            if (item.itemLevel < levelMax)
            {
                selectableList.Add(item);
            }
        }
    }

    public int SelectItem()
    {
        if(selectableList.Count == 0)
        {
            return fallbackItem.itemIndex;
        }

        int index = Random.Range(0, selectableList.Count);
        int selectedItem = selectableList[index].itemIndex;
        selectableList.RemoveAt(index);
        return selectedItem;
    }

    [Header("chooser")]
    [SerializeField] public GameObject chooserA;
    [SerializeField] public GameObject chooserB;
    [SerializeField] public GameObject chooserC;


}
