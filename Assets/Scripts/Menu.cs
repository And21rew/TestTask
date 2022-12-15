using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject settingsScreen;

    public void StartGame() => SceneManager.LoadScene("1_Game");

    public void SwitchSettingsScreen() => settingsScreen.SetActive(!settingsScreen.activeInHierarchy);

    public void CloseGame() => SceneManager.LoadScene("0_Menu");

    public void CloseApplication() => Application.Quit();
}
