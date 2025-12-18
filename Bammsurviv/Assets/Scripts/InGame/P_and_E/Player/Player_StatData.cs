using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player_StatData : MonoBehaviour
{
    [System.Serializable]
    public class Stats {
        public int MaxHP;//MaxHealth
        public float MS;//MoveSpeed
        public float Damage;//Damage Bonus for all type attack
        public float AMS;//bonus speed of projectile-type attack
        public float Duration;//bonus duration of field-type attack
        public int AAmount;//bonus amount of all type attack, ps: some attacks don't use this
        public float CDown;//bonus cooldown of all type attack
        public float Magnet;//player's magnetbox scale
        public float HPGen;//player's Health generation per second
    }

    [SerializeField] public Stats player_BaseStat = new Stats {
        MaxHP = 100,
        MS = 3,
        Damage = 0f,
        AMS = 0f,
        Duration = 0f,
        AAmount = 0,
        CDown = 0f,
        Magnet = 1f,
        HPGen = 0.1f,
    };
    [SerializeField] public Stats player_BonusStat = new Stats {
        MaxHP = 0,
        MS = 0,
        Damage = 0f,
        AMS = 0f,
        Duration = 0f,
        AAmount = 0,
        CDown = 0f,
        Magnet = 0f,
        HPGen = 0f,
    };
    [SerializeField] public Stats player_finalStat = new Stats{};

    void Awake()
    {
        player_finalStat.MaxHP = player_BaseStat.MaxHP + (20*player_BonusStat.MaxHP);
        player_finalStat.MS = player_BaseStat.MS + (0.2f*player_BonusStat.MS);
        player_finalStat.Damage = player_BaseStat.Damage + (0.1f*player_BonusStat.Damage);
        player_finalStat.AMS = player_BaseStat.AMS + (0.2f*player_BonusStat.AMS);
        player_finalStat.Duration = player_BaseStat.Duration + (0.25f*player_BonusStat.Duration);
        player_finalStat.AAmount = player_BaseStat.AAmount + (player_BonusStat.AAmount);
        player_finalStat.CDown = player_BaseStat.CDown + (0.2f* player_BonusStat.CDown);
        player_finalStat.Magnet = player_BaseStat.Magnet + (0.2f* player_BonusStat.Magnet);
        player_finalStat.HPGen = player_BaseStat.HPGen + (1.5f* player_BonusStat.HPGen);
    }

    void Update()
    {
        player_finalStat.MaxHP = player_BaseStat.MaxHP + (20 * player_BonusStat.MaxHP);
        player_finalStat.MS = player_BaseStat.MS + (0.2f * player_BonusStat.MS);
        player_finalStat.Damage = player_BaseStat.Damage + (0.1f * player_BonusStat.Damage);
        player_finalStat.AMS = player_BaseStat.AMS + (0.2f * player_BonusStat.AMS);
        player_finalStat.Duration = player_BaseStat.Duration + (0.25f * player_BonusStat.Duration);
        player_finalStat.AAmount = player_BaseStat.AAmount + (player_BonusStat.AAmount);
        player_finalStat.CDown = player_BaseStat.CDown + (0.2f * player_BonusStat.CDown);
        player_finalStat.Magnet = player_BaseStat.Magnet + (0.2f * player_BonusStat.Magnet);
        player_finalStat.HPGen = player_BaseStat.HPGen + (0.1f * player_BonusStat.HPGen);
    }
}