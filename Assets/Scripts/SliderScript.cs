using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject menuPanel;
    public Slider slider;
    public GameObject pauseButton;
    public GameObject timer;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(progressBar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator progressBar() 
    {
        yield return new WaitForSeconds(0.10f);
        slider.value -= 0.3f;
        if (slider.value == 0) 
        {
            menuPanel.SetActive(true);
            
            pauseButton.SetActive(false);
            
            //timer.SetActive(false);
            gameOver = true;
            
        }
        StartCoroutine(progressBar());
    }

    public void increaseProgressBar(int points) 
    {
        slider.value += (float)points;
    }

    
}
