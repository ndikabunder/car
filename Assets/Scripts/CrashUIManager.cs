using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrashUIManager : MonoBehaviour
{
    public GameObject crashPanel;

    void Start()
    {
        crashPanel.SetActive(false); // pastikan panel tidak muncul dulu
    }

    public void ShowCrashPanel()
    {
        crashPanel.SetActive(true);
    }

    public void RestartScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0); // balik ke scene index 0
    }
}
