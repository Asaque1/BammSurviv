using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyM_KRH : MonoBehaviour
{
    [SerializeField] public GameObject SW;
    [SerializeField] public GameObject HT;

    void Start()
    {
        SW.SetActive(false); HT.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && SW.activeSelf == true) {
            onSWOut();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame && HT.activeSelf == true)
        {
            onHTWOut();
        }

        if (SW.activeSelf == true && Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            ToPrevWeap();
        }
        if (SW.activeSelf == true && Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            ToNextWeap();
        }

        selectedWeapImg = weaps[weapIndex].img;
        selectedWeapText.text = weaps[weapIndex].name;
    }
    public void onSBClicked(){SW.SetActive(true);}
    public void onSWOut(){SW.SetActive(false);}

    //lobby to SW

    [System.Serializable] public class WeapData //weapon datas for weapon list
    {
       public string name;
       public Image img;
    }

    [SerializeField] public List<WeapData> weaps = new List<WeapData>(); //weapon list for choosing start weapon
    [SerializeField] public int weapIndex=0; //Data for Ingame weapon and Index;

    [SerializeField] public Image selectedWeapImg;
    [SerializeField] public TMPro.TextMeshProUGUI selectedWeapText;

    public void ToNextWeap() {
        if (weapIndex < weaps.Count-1) {
            weapIndex++;
        }
        else
        {
            weapIndex = 0;
        }
    }
    public void ToPrevWeap() {
        if (weapIndex != 0)
        {
            weapIndex--;
        }
        else
        {
            weapIndex = weaps.Count-1;
        }
    }

    //switch start weapons
    public void onHTWClicked() { HT.SetActive(true); }
    public void onHTWOut() {HT.SetActive(false); }
    
    //HT window opens

    public void GameStart()
    {
        SceneManager.LoadScene("City");
    }

    //SceneMove

}
