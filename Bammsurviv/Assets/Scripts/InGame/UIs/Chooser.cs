using UnityEditor.Search;
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
    [SerializeField] public UnityEvent<int> itemChoosed;
    public int itemChoosedIndex;
    public void GetItem(ChooseM.Items seledItem)
    {
        itemName.text = seledItem.itemName;
        itemDesc.text = seledItem.itemDesc;
        itemSprite.sprite = seledItem.itemSprite;
        itemChoosedIndex = seledItem.itemIndex;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        itemChoosed.Invoke(itemChoosedIndex);
    }

}
