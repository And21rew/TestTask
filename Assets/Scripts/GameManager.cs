using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private QueueStep queue;
    private UIGameManager uiManager;

    private GameObject[] map;
    [HideInInspector] public GameObject[] playersGameObject;
    [HideInInspector] public Player[] players;

    private readonly int maxStepCount = 6;

    private void Awake()
    {
        uiManager = gameObject.GetComponent<UIGameManager>();
        queue = gameObject.GetComponent<QueueStep>();
        map = GameObject.FindGameObjectsWithTag("Step");
        BubbleSortArray(ref map);
        playersGameObject = GameObject.FindGameObjectsWithTag("Player");
        BubbleSortArray(ref playersGameObject);
    }

    private void BubbleSortArray(ref GameObject[] array)
    {
        GameObject temp;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                int firstNumber = int.Parse(array[j].name.Split("_")[1]);
                int secondNumber = int.Parse(array[j + 1].name.Split("_")[1]);

                if (firstNumber > secondNumber)
                {
                    temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    public void StartGame()
    {
        SetPlayersStartPosition();
        queue.CreateQueue();
    }

    private void SetPlayersStartPosition()
    {
        for (int i = 0; i < players.Length; i++)
            players[i].CurrentPosition = map[0];
    }

    public void MakeStep()
    {
        var playerForStep = players[queue.GetPlayerForStep()];
        int countStep = Random.Range(1, maxStepCount);

        uiManager.SetCountSteps(countStep);

        int currentPosition = FindPlayerMapCell(playerForStep).GetComponent<Step>().StepNumber;
        int potentialPosition = countStep + currentPosition;
        playerForStep.CurrentPosition = CanMakeStep(potentialPosition) ? map[potentialPosition] : map[^1];

        if (queue.GetQueueLength() > 1)
            queue.PassStepNextPlayer(playerForStep.gameObject);

        if (CheckPlayerEnd(playerForStep))
            uiManager.GameEnd(playerForStep.Name);
    }

    private GameObject FindPlayerMapCell(Player player) => map.Where(cell => cell == player.CurrentPosition).FirstOrDefault();

    private bool CanMakeStep(int potentialPosition) => potentialPosition <= map.Length - 1;

    private bool CheckPlayerEnd(Player player) => player.CurrentPosition == map[^1];
}
