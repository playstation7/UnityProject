using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    private int offset = 0;
    private bool catchfishing;

    public GameObject fishOnHook;
    public GameObject progressBar;
    
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


            if (worldPosition.y + offset < 8.3f && worldPosition.y > 0.5 && !progressBar.GetComponent<SliderScript>().gameOver)
            {
                transform.position = new Vector3(transform.position.x, worldPosition.y + offset, 1);
                if (worldPosition.y > 8f + offset && catchfishing)
                {
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    SliderScript script = progressBar.GetComponent<SliderScript>();
                    script.increaseProgressBar(10);
                }
            }
        }
        else if (Input.touchCount > 0 && !progressBar.GetComponent<SliderScript>().gameOver)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 toucPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (toucPosition.y + offset < 8.3f && toucPosition.y > 0.5)
            {
                transform.position = new Vector3(transform.position.x, toucPosition.y + offset, 1);
                if (toucPosition.y > 8f + offset && catchfishing)
                {
                    catchfishing = false;
                    fishOnHook.SetActive(false);
                    
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

