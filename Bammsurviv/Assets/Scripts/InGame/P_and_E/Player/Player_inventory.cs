using UnityEngine;

public class Player_inventory : MonoBehaviour
{
    [SerializeField] public Player_StatData pData;
    [SerializeField] public ChooseM cM;
    [SerializeField] public Weapon_Axe axe;
    [SerializeField] public weapon_Bat bat;
    [SerializeField] public weapon_Granade gra;
    [SerializeField] public weapon_Gun gun;
    [SerializeField] public Weapon_Knife kni;
    [SerializeField] public weapon_Remote rem;
    void Start()
    {
        itemIndexListner(LobbyM_KRH.Instance.value);
        Destroy(LobbyM_KRH.Instance);
    }

    private void OnEnable()
    {
        Chooser.OnItemChosen += itemIndexListner;
    }

    private void OnDisable()
    {
        Chooser.OnItemChosen -= itemIndexListner;
    }
    public void itemIndexListner(int index)
    {
        Debug.Log($"{index} got");
        if (index < 0) return;
        else{
        cM.itemList[index].itemLevel++;
            switch (index)
            {
                case 0:
                    axe.level++;
                    break;
                case 1:
                    bat.level++;
                    break;
                case 2:
                    gra.level++;
                    break;
                case 3:
                    gun.level++;
                    break;
                case 4:
                    kni.level++;
                    break;
                case 5:
                    rem.level++;
                    break;
                case 6:
                    pData.player_BonusStat.HPGen ++;
                    break;
                case 7:
                    pData.player_BonusStat.MS ++;
                    break;
                case 8:
                    pData.player_BonusStat.Duration ++;
                    break;
                case 9:
                    pData.player_BonusStat.AAmount ++;
                    break;
                case 10:
                    pData.player_BonusStat.Damage ++;
                    break;
                case 11:
                    pData.player_BonusStat.CDown ++;
                    break;
                default:
                    break;
            }
        }
    }

}
