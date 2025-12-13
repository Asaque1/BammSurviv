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
    [SerializeField] public Stats player_finalStat = new Stats {
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}