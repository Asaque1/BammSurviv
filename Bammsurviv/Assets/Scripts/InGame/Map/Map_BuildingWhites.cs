using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map_BuildingWhites : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            FadeObject(0.2f);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            FadeObject(1f);
    }

    private void FadeObject(float targetAlpha)
    {
            Color color = sr.color;
            color.a = targetAlpha;
            sr.color = color;

    }

}
