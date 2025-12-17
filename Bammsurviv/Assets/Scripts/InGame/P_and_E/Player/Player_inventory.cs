using UnityEngine;

public class Player_inventory : MonoBehaviour
{
    [SerializeField] public Player_StatData pData;
    [SerializeField] public ChooseM cM;
    [SerializeField] public Weapon_Axe axe;
    [SerializeField] public Weapon_Bat bat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemIndexListner(int index)
    {
        if (index < 0) return;
        else{
        cM.itemList[index].itemLevel++;
            if (index > 5)
            {
                switch (index)
                {
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
                }
            }
            else
            {
                switch (index) {
                    case 0:
                        axe.level++;
                        break;
                    case 1:
                        bat.level++;
                        break;
                }
            }
        }
    }

}
