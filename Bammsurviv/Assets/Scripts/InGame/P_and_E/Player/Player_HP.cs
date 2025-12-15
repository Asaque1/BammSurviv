using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player_HP : MonoBehaviour, IDamagable
{
    [Header("UIs")]
    [SerializeField] public GameObject hp_UI;
    [SerializeField] public Image nowHP_UI;

    [Header("parameters")]
    [SerializeField] public Player_StatData pData;
    [SerializeField] public float nowHP;

    [Header("die event")]
    [SerializeField] UnityEvent onDie;

    [Header("UImoving")]
    [SerializeField] public Transform playerTransform;
    [SerializeField] public Vector3 worldOffset = new Vector3(0,0.7f,0);
    [SerializeField] public Camera cam;
    
    void Start()
    {
        nowHP = pData.player_finalStat.MaxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nowHP = Mathf.Min(nowHP + pData.player_finalStat.HPGen * Time.fixedDeltaTime, pData.player_finalStat.MaxHP);
        nowHP_UI.fillAmount = nowHP / pData.player_finalStat.MaxHP;
    }

    void LateUpdate()
    {
        Vector3 worldPos = playerTransform.position + worldOffset;
        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);
        hp_UI.gameObject.transform.position = screenPos;
    }

    void GetDamage(float damage) {
        nowHP -= damage;
        if (nowHP <= 0) Die();
    }
    public void Die()
    {
        onDie.Invoke();
    }
}
