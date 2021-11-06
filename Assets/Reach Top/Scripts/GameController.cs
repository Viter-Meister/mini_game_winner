using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float BoxeChangePlaceSpeed = 0.5f;
    public Transform BoxeToPlace;
    int i = 0, j = 4;
    float oldY = -1, newY = -1;

    public GameObject BoxeToCreateBlue, AllBoxesBlue;

    private bool IsWin;

    public Text Winner;

    public float TimerTime = 3;
    public Text TimerText;

    private bool IsWait = false;

    private Vector2[] AllSpawnPositionBlue = new Vector2[6] {
        new Vector2(-8, -4),
        new Vector2(-7, -4),
        new Vector2(-6, -4),
        new Vector2(-5, -4),
        new Vector2(-4, -4),
        new Vector2(-3, -4),
    };

    private int[,] AllHeldPosition = new int[7, 6]
    {
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0 },
    };

    private IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(Wait());
            IsWait = true;
            BoxeToPlace.gameObject.SetActive(true);
            yield return StartCoroutine(ShowBoxePlace());
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && BoxeToPlace != null && IsWait)
        {
            BoxeToPlace.gameObject.SetActive(false);

            GameObject NewBoxe = Instantiate(BoxeToCreateBlue,
            BoxeToPlace.position,
            Quaternion.identity);
            NewBoxe.transform.SetParent(AllBoxesBlue.transform);

            TakePosition(NewBoxe.transform.position);

            IsWait = false;

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    if (AllHeldPosition[i, j] == 1)
                    {
                        newY = i;
                        break;
                    }

            if (newY > oldY)
            {
                for (int i = 0; i < 6; i++)
                    AllSpawnPositionBlue[i].y += 1;
                oldY = newY;
            }

            SpawnPosition();
        }

        if (!IsWin && newY == 6)
        {
            IsWin = true;
            StopAllCoroutines();
            Destroy(BoxeToPlace.gameObject);
            Winner.text = "Blue won!";
        }

        if (TimerTime < 1)
            Destroy(TimerText.gameObject);
        else
        {
            TimerText.text = Math.Round(TimerTime).ToString();
            TimerTime -= Time.deltaTime;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

    IEnumerator ShowBoxePlace()
    {
        while (IsWait)
        {
            SpawnPosition();

            yield return new WaitForSeconds(BoxeChangePlaceSpeed);
        }
    }

    private void SpawnPosition()
    {
        if (i <= 5)
        {
            BoxeToPlace.position = AllSpawnPositionBlue[i];
            i += 1;
        }
        else if (j > 0)
        {
            BoxeToPlace.position = AllSpawnPositionBlue[j];
            j -= 1;
        }
        else
        {
            i = 0;
            j = 4;
            BoxeToPlace.position = AllSpawnPositionBlue[i];
            i += 1;
        }
    }

    private void TakePosition(Vector2 pos)
    {
        switch (pos.x)
        {
            case -8:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 0] == 0)
                        {
                            AllHeldPosition[i, 0] = 1;
                            break;
                        }
                    break;
                }
            case -7:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 1] == 0)
                        {
                            AllHeldPosition[i, 1] = 1;
                            break;
                        }
                    break;
                }
            case -6:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 2] == 0)
                        {
                            AllHeldPosition[i, 2] = 1;
                            break;
                        }
                    break;
                }
            case -5:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 3] == 0)
                        {
                            AllHeldPosition[i, 3] = 1;
                            break;
                        }
                    break;
                }
            case -4:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 4] == 0)
                        {
                            AllHeldPosition[i, 4] = 1;
                            break;
                        }
                    break;
                }
            case -3:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 5] == 0)
                        {
                            AllHeldPosition[i, 5] = 1;
                            break;
                        }
                    break;
                }
        }
    }
}