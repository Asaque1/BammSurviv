using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    string name;//name of weapon
    string desc;//description for when player get this item

    float damage; //base damage for weapon
    float cTime; //cooltime for use to use time
}