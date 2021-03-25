using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    public GameObject menu;
    public GameObject gameMenu;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void OnNewGameClicked()
    {
        gameMenu.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnEndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
    }
}
