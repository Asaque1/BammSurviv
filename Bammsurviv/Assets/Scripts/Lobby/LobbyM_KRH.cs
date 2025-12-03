using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyM_KRH : MonoBehaviour
{
    [SerializeField] public GameObject SW;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && SW.activeSelf == true) {
            onSWOut();
        }
    }
    public void onSBClicked(){SW.SetActive(true);}
    public void onSWOut(){SW.SetActive(false);}

    //lobby to SW

    [System.Serializable] public class WeapData
    {
        string name;
        Sprite img;
    }

    [SerializeField] public List<WeapData> weaps = new List<WeapData>();

    public void onNextWeap() { }
    public void onPrevWeap() { }

}
