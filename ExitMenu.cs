using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public GameObject panel;
    private bool activePanel;

    public GameObject helpPanel;
    private bool activeHelpPanel;

    public void YesOption(bool option)
    {
        File.WriteAllText(Application.dataPath + "/save.txt", PlayerPrefs.GetInt("levelAt").ToString());
        QuitGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NoOption(bool option)
    {
        panel.SetActive(false);
        activePanel = false;
        Time.timeScale = 1;         //repornim timpul
    }

    public void BackToTheMenu(bool option)
    {
        //PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex);
        File.WriteAllText(Application.dataPath + "/save.txt", SceneManager.GetActiveScene().buildIndex.ToString());
        SceneManager.LoadScene(1);
    }

    public void HelpMenu(bool option)
    {
        PlayerPrefs.SetInt("BeforeHelpScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(14);
    }

    public void ReturnHelpMenu(bool option)
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("BeforeHelpScene"));
    }

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("Panel");
        panel.SetActive(false);
        activePanel = false;

        helpPanel = GameObject.FindGameObjectWithTag("HelpPanel");
        helpPanel.SetActive(false);
        activeHelpPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        //daca se apasa Esc, atunci daca panoul era dezactivat, este activat, altfel, este activat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!activePanel)
            {
                panel.SetActive(true);
                activePanel = true;
                Time.timeScale = 0;     // se pune pauza jocului
            }
            else
            {
                panel.SetActive(false);
                activePanel = false;
                Time.timeScale = 1;     // se opreste pauza jocului
            }
        }

        // F1 meniu ajutor
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!activeHelpPanel)
            {
                helpPanel.SetActive(true);
                activeHelpPanel = true;
                Time.timeScale = 0;     // se pune pauza jocului
            }
            else
            {
                helpPanel.SetActive(false);
                activeHelpPanel = false;
                Time.timeScale = 1;     // se opreste pauza jocului
            }
        }
    }
}
