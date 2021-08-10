using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    private int offset = 0;
    public bool catchfishing;

    public GameObject fishOnHook;
    public GameObject progressBar;
    public GameObject AirBalls;

    public bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


            if (worldPosition.y + offset < 4f && worldPosition.y > -4 && !progressBar.GetComponent<SliderScript>().gameOver && !isPaused)
            {
                transform.position = new Vector3(transform.position.x, worldPosition.y + offset, 1);
                if (worldPosition.y > 3.7f + offset && catchfishing)
                {
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    SliderScript script = progressBar.GetComponent<SliderScript>();
                    script.increaseProgressBar(10);
                    AirBalls.SetActive(false);
                    AirBalls.SetActive(true);
                }
            }
        }
        else if (Input.touchCount > 0 && !progressBar.GetComponent<SliderScript>().gameOver && !isPaused)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 toucPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (toucPosition.y + offset < 4f && toucPosition.y > -4)
            {
                transform.position = new Vector3(transform.position.x, toucPosition.y + offset, 1);
                if (toucPosition.y > 3.7f + offset && catchfishing)
                {
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    SliderScript script = progressBar.GetComponent<SliderScript>();
                    script.increaseProgressBar(10);
                    AirBalls.SetActive(false);
                    AirBalls.SetActive(true);
                }
            }
        }
    }
    
    public void catchFish(GameObject fish) 
    {
        if (!catchfishing) 
        {
            fishOnHook.SetActive(true);
            catchfishing = true;
            Destroy(fish);
        }
    }

    
}

