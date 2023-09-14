using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackIndicator : MonoBehaviour
{
    SpriteRenderer Image;
    public GameObject go;

    private void Start()
    {
        Image = go.GetComponent<SpriteRenderer>();
    }
   
    IEnumerator FadeIn()
    {
        for (int i = 0; i < 10; i++)
        {
            float f = 1 / 10.0f;
            Color c = Image.material.color;
            c.a = f;
            Image.material.color = c;
            yield return new WaitForSeconds(0.1f);

        }
    }
    IEnumerator FadeOut()
    {
        for (int i = 10; i >= 0; i--)
        {
            float f = 1 / 10.0f;
            Color c = Image.material.color;
            c.a = f;
            Image.material.color = c;
            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator Delay()
    {
        yield return StartCoroutine(FadeIn());
        yield return StartCoroutine(FadeOut());
    }
}