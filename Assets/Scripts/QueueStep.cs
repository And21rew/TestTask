using UnityEngine;

public class QueueStep : MonoBehaviour
{
    private GameManager gameManager;
    private bool[] queue;

    private void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }

    public int GetQueueLength() => queue.Length;

    public void CreateQueue()
    {
        queue = new bool[gameManager.players.Length];

        for (int i = 0; i < queue.Length; i++)
            queue[i] = i == 0;
    }

    public int GetPlayerForStep()
    {
        for (int i = 0; i < queue.Length; i++)
            if (queue[i]) return i;

        return 0;
    }

    public void PassStepNextPlayer(GameObject player)
    {
        ClearQueue();
        int playerNumber = int.Parse(player.name.Split("_")[1]) - 1;

        if (playerNumber + 1 == queue.Length) 
            queue[0] = true;
        else 
            queue[playerNumber + 1] = true;
    }

    private void ClearQueue()
    {
        for (int i = 0; i < queue.Length; i++)
            queue[i] = false;
    }

    //public void ResizeQueue(GameObject player)
    //{
    //    int indexQueue = int.Parse(player.name.Split("_")[1]) - 1;
    //    var temp = new List<bool>(queue);
    //    temp.RemoveAt(indexQueue);
    //    queue = temp.ToArray();
    //}
}
