using System.Collections;
using UnityEngine;

public class BoardDice : MonoBehaviour
{
    public BoardMain main;
    public Transform UpSide;
    public Transform[] sides;

    void OnEnable()
    {
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        yield return new WaitForSeconds(1);
        float speed;
        for (int i = 1; i < 25; i++)
        {
            speed = i / 100.0f;
            transform.Rotate(new Vector3(Random.Range(0, 4) * 90, Random.Range(0, 4) * 90, Random.Range(0, 4) * 90));
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < sides.Length; i++)
            if (Vector3.Distance(sides[i].position, UpSide.position) < 0.2f)
                main.FromDice(i);
            
        gameObject.SetActive(false);
    }
}
