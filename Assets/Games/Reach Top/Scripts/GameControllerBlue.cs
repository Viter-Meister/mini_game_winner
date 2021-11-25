using System;
using System.Collections;
using UnityEngine;

public class GameControllerBlue : MonoBehaviour
{
    public float BoxeChangePlaceSpeed;
    public Transform BoxeToPlace;
    public GameObject BoxeToCreate, AllBoxes;

    public float oldY = -1, newY = -1;

    private int i = 0, j = 4;

    private bool IsWait = false;

    private Vector2[] AllSpawnPosition = new Vector2[6] {
        new Vector2(-7, -6.65f),
        new Vector2(-6, -6.65f),
        new Vector2(-5, -6.65f),
        new Vector2(-4, -6.65f),
        new Vector2(-3, -6.65f),
        new Vector2(-2, -6.65f),
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
            yield return new WaitForSeconds(2.5f);
            IsWait = true;
            BoxeToPlace.gameObject.SetActive(true);
            yield return StartCoroutine(ShowBoxePlace());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BoxeToPlace != null && IsWait)
        {
            BoxeToPlace.gameObject.SetActive(false);
            IsWait = false;

            GameObject NewBoxe = Instantiate(BoxeToCreate,
                BoxeToPlace.position,
                Quaternion.identity);

            NewBoxe.transform.SetParent(AllBoxes.transform);

            TakePosition(NewBoxe.transform.position);

            SetNewY();

            ChangeSpawnPosition();

            ChangeSpeed((int)Math.Truncate(newY));

            SpawnPosition();
        }
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
            BoxeToPlace.position = AllSpawnPosition[i];
            i += 1;
        }
        else if (j > 0)
        {
            BoxeToPlace.position = AllSpawnPosition[j];
            j -= 1;
        }
        else
        {
            i = 0;
            j = 4;
            BoxeToPlace.position = AllSpawnPosition[i];
            i += 1;
        }
    }

    private void TakePosition(Vector2 pos)
    {
        switch (pos.x)
        {
            case -7:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 0] == 0)
                        {
                            AllHeldPosition[i, 0] = 1;
                            break;
                        }
                    break;
                }
            case -6:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 1] == 0)
                        {
                            AllHeldPosition[i, 1] = 1;
                            break;
                        }
                    break;
                }
            case -5:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 2] == 0)
                        {
                            AllHeldPosition[i, 2] = 1;
                            break;
                        }
                    break;
                }
            case -4:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 3] == 0)
                        {
                            AllHeldPosition[i, 3] = 1;
                            break;
                        }
                    break;
                }
            case -3:
                {
                    for (int i = 0; i < 7; i++)
                        if (AllHeldPosition[i, 4] == 0)
                        {
                            AllHeldPosition[i, 4] = 1;
                            break;
                        }
                    break;
                }
            case -2:
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

    private void ChangeSpeed(int i)
    {
        BoxeChangePlaceSpeed = 0.13f - i * 0.1f / 6;
    }

    void SetNewY()
    {
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 6; j++)
                if (AllHeldPosition[i, j] == 1)
                {
                    newY = i;
                    break;
                }
    }

    void ChangeSpawnPosition()
    {
        if (newY > oldY)
        {
            for (int i = 0; i < 6; i++)
                AllSpawnPosition[i].y += 1;
            oldY = newY;
        }
    }
}