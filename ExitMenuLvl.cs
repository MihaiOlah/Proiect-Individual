using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitMenuLvl : MonoBehaviour
{
    public GameObject panel;
    private bool activePanel;

    public void Back(bool option)
    {
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //panel = GameObject.FindGameObjectWithTag("Panel");
        //panel.SetActive(false);
        //activePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
    }
}
