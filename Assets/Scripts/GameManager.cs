using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] map;
    private GameObject[] players;
    private bool[] queueStep;

    private readonly int maxCountPlayers = 4;
    private readonly float distanceToAngleFromCenterStep = 0.5f;
    private readonly int maxStepCount = 6;

    private void Awake()
    {
        map = GameObject.FindGameObjectsWithTag("Step");
        players = new GameObject[maxCountPlayers];
        queueStep = new bool[maxCountPlayers];
        GameObject.FindGameObjectsWithTag("Player").CopyTo(players, 0);
    }

    private void Start()
    {
        InitializePlayerStartPosition();
        InitializeQueueStep();
    }

    private void InitializePlayerStartPosition()
    {
        if (players[0] != null) players[0].transform.position = new Vector3(map[0].transform.position.x - distanceToAngleFromCenterStep, map[0].transform.position.y + distanceToAngleFromCenterStep, 0);
        if (players[1] != null) players[1].transform.position = new Vector3(map[0].transform.position.x + distanceToAngleFromCenterStep, map[0].transform.position.y - distanceToAngleFromCenterStep, 0);
        if (players[2] != null) players[2].transform.position = new Vector3(map[0].transform.position.x + distanceToAngleFromCenterStep, map[0].transform.position.y + distanceToAngleFromCenterStep, 0);
        if (players[3] != null) players[3].transform.position = new Vector3(map[0].transform.position.x - distanceToAngleFromCenterStep, map[0].transform.position.y - distanceToAngleFromCenterStep, 0);
    }

    private void SetPlayerPosition(GameObject player, int step, int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                player.transform.position = new Vector3(map[step].transform.position.x + distanceToAngleFromCenterStep, map[step].transform.position.y - distanceToAngleFromCenterStep, 0);
                break;
            case 2:
                player.transform.position = new Vector3(map[step].transform.position.x - distanceToAngleFromCenterStep, map[step].transform.position.y - distanceToAngleFromCenterStep, 0);
                break;
            case 3:
                player.transform.position = new Vector3(map[step].transform.position.x + distanceToAngleFromCenterStep, map[step].transform.position.y + distanceToAngleFromCenterStep, 0);
                break;
            case 4:
                player.transform.position = new Vector3(map[step].transform.position.x - distanceToAngleFromCenterStep, map[step].transform.position.y + distanceToAngleFromCenterStep, 0);
                break;
        }
    }

    private void InitializeQueueStep()
    {
        for (int i = 0; i < queueStep.Length; i++)
            queueStep[i] = i == 0;
    }

    public void MakeStep()
    {
        int stepCount = Random.Range(1, maxStepCount + 1);
        Debug.Log($"Выпало число = {stepCount}"); //TODO

        for (int i = 0; i < queueStep.Length; i++)
        {
            if (queueStep[i] && players[i] != null)
            {
                queueStep[i] = false;
                if (i == queueStep.Length - 1) queueStep[0] = true;
                else queueStep[i + 1] = true;
                var playerNumber = int.Parse(players[i].name.Split("_")[1]);
                switch (playerNumber)
                {
                    case 1:
                        players[i].transform.position = new Vector3(map[stepCount].transform.position.x + distanceToAngleFromCenterStep, map[stepCount].transform.position.y - distanceToAngleFromCenterStep, 0);
                        break;
                    case 2:
                        players[i].transform.position = new Vector3(map[stepCount].transform.position.x - distanceToAngleFromCenterStep, map[stepCount].transform.position.y - distanceToAngleFromCenterStep, 0);
                        break;
                    case 3:
                        players[i].transform.position = new Vector3(map[stepCount].transform.position.x + distanceToAngleFromCenterStep, map[stepCount].transform.position.y + distanceToAngleFromCenterStep, 0);
                        break;
                    case 4:
                        players[i].transform.position = new Vector3(map[stepCount].transform.position.x - distanceToAngleFromCenterStep, map[stepCount].transform.position.y + distanceToAngleFromCenterStep, 0);
                        break;
                }
                break;
            }
        }
    }
}
