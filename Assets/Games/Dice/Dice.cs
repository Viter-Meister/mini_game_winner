using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[0];
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        int RandomDiceSide = 0;
        for (int i = 0; i < 25; i++)
        {
            RandomDiceSide = Random.Range(0, 24);
            rend.sprite = diceSides[RandomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
