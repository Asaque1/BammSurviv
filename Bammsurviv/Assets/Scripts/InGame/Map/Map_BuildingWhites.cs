using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map_BuildingWhites : MonoBehaviour
{
    [SerializeField] float fadeDuration = 0.5f;    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeObject(0.2f));
            Debug.Log("getIn");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeObject(1f));
            Debug.Log("getOut");
        }
    }

    private IEnumerator FadeObject(float targetAlpha)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) yield break;
            Color color = sr.color;
            color.a = targetAlpha;
            sr.color = color;
        
        Debug.Log("Done");

    }

}
