using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public GameObject menu;
    public GameObject newGameButton;

    public void OnNewGameClicked()
    {
        menu.SetActive(false);
        newGameButton.SetActive(false);
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

}
