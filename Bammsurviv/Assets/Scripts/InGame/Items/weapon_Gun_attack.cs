using UnityEngine;

public class weapon_Gun_attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onAttackEnd()
    {
        Destroy(this.gameObject);
    }

}
