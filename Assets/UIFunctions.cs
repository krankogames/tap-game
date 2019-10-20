using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    public GameObject menu;

    public void OnNewGameClicked()
    {
        menu.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

}
