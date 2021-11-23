using System.Collections;
using UnityEngine;

public class BoardDice : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        float speed;
        for (int i = 1; i < 25; i++)
        {
            speed = i / 100.0f;
            transform.Rotate(new Vector3(Random.Range(0, 4) * 90, Random.Range(0, 4) * 90, Random.Range(0, 4) * 90));
            yield return new WaitForSeconds(speed);
        }
    }
}
