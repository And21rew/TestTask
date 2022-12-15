using UnityEngine;

public class LoadPlayersCount : MonoBehaviour
{
    [SerializeField] private GameObject writePlayersNameScreen;
    [SerializeField] private GameObject selectPlayersCountScreen;
    [SerializeField] private GameObject makeStepButton;

    [SerializeField] private GameObject[] playersUI;
    [SerializeField] private GameObject[] playersInputUI;

    GameManager gameManager;

    private void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        makeStepButton.SetActive(false);
        selectPlayersCountScreen.SetActive(true);
    }

    public void SelectPlayersCount(int count)
    {
        ActivePlayers(count);
        InitializePlayers();
        selectPlayersCountScreen.SetActive(false);
        writePlayersNameScreen.SetActive(true);
        ActiveUICountPlayers(count);
    }

    private void ActivePlayers(int count)
    {
        for (int i = 0; i < gameManager.playersGameObject.Length; i++)
            gameManager.playersGameObject[i].SetActive(i < count);
    }

    private void InitializePlayers()
    {
        int countActivePlayers = 0;

        for (int i = 0; i < gameManager.playersGameObject.Length; i++)
            if (gameManager.playersGameObject[i].activeInHierarchy)
                countActivePlayers++;

        gameManager.players = new Player[countActivePlayers];

        for (int i = 0; i < gameManager.players.Length; i++)
            gameManager.players[i] = gameManager.playersGameObject[i].GetComponent<Player>();
    }

    private void ActiveUICountPlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            playersUI[i].SetActive(true);
            playersInputUI[i].SetActive(true);
        }
    }

    public void StartGame()
    {
        for (int i = 0; i < gameManager.players.Length; i++)
            gameManager.players[i].Name = playersInputUI[i].GetComponent<InputName>().NameText;

        writePlayersNameScreen.SetActive(false);
        makeStepButton.SetActive(true);

        gameManager.StartGame();
    }
}
