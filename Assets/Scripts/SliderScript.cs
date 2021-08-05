using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;
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
        StartCoroutine(progressBar());
    }

    public void increaseProgressBar(int points) 
    {
        slider.value += (float)points;
    }
}
