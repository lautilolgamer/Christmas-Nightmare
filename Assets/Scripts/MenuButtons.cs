using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscapeLevel");
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
