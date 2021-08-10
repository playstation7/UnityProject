
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonsUI : MonoBehaviour
{
    public GameObject hook;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        gameObject.SetActive(false);
        hook.GetComponent<Hook>().isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseButton.SetActive(true);
        hook.GetComponent<Hook>().isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
