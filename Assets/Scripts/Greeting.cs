using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : MonoBehaviour
{
    void Start()
    {   
        StartCoroutine(disappearance());
    }

    IEnumerator disappearance()
    {   
        yield return new WaitForSeconds(0.9f);
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();
        for (float i = 1; i > -0.1; i=i-0.01f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
