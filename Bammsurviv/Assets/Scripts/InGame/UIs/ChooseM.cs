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

    public static ChooseM Instance { get; private set; }

    private void Awake()
    {
        // 이미 인스턴스가 존재하면 새로 생성된 자신은 제거
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 싱글톤 인스턴스 할당
        Instance = this;
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

    private void Start()
    {
        times = this.gameObject.GetComponent<GameStateandTM>();
    }
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

    public Items SelectItem()
    {
        if(selectableList.Count == 0)
        {
            return fallbackItem;
        }

        int index = Random.Range(0, selectableList.Count);
        Items selectedItem = selectableList[index];
        selectableList.RemoveAt(index);
        return selectedItem;
    }

    [Header("chooser")]
    [SerializeField] public GameObject chooserContainer;
    [SerializeField] public Chooser chooserA;
    [SerializeField] public Chooser chooserB;
    [SerializeField] public Chooser chooserC;
    GameStateandTM times;

    [ContextMenu("choiceStart")]
    public void onLevelUp()
    {
        times.OnPauseStart();
        InitialzeSelector();
        chooserA.GetItem(SelectItem());
        chooserB.GetItem(SelectItem());
        chooserC.GetItem(SelectItem());
        chooserContainer.SetActive(true);
    }
    private void OnEnable()
    {
        Chooser.OnItemChosen += onChooseEnd;
    }

    private void OnDisable()
    {
        Chooser.OnItemChosen -= onChooseEnd;
    }
    public void onChooseEnd(int temp)
    {
        times.OnPauseEnd();
        chooserContainer.SetActive(false);
    }

    //public void onBoxOpen(){}

}
