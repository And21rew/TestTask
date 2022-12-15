using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private Text countSteps;
    [SerializeField] private GameObject makeStepButton;
    [SerializeField] private Text winner;
    [SerializeField] private GameObject winScreen;

    public void SetCountSteps(int count) => countSteps.text = $"Number drop: {count}";

    public void GameEnd(string winnerName)
    {
        makeStepButton.SetActive(false);
        winner.text = $"{winnerName} win the game!!!";
        winScreen.SetActive(true);
    }
}
