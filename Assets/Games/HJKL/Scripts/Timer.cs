using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    public float minutes = 0.5f;

    void Start()
    {
        StartCoroutine(GameTimer(minutes)); // set minutes for a game here
    }

    IEnumerator GameTimer(float minutes)
    {
        yield return new WaitForSeconds(minutes * 60);
        print(minutes + " minutes was passed");
    }
}
