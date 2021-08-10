using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float time = 0;
    public GameObject slider;
    public GameObject gameOverText;
    public GameObject sadPinguin;
    public GameObject smilingPpinguin;
    public GameObject vfx;




    private int seconds,minutes;
    // Start is called before the first frame update
    // Update is called once per frame

    
    void Update()
    {
        if (!slider.gameObject.GetComponent<SliderScript>().gameOver)
        {
            time += Time.deltaTime;
            minutes = (int)Mathf.Round(time) / 60;
            seconds = (int)Mathf.Round(time) % 60;
            if (TimeStringLessTen(seconds))
            {
                timerText.text = string.Format(@"{0}:0{1}", minutes, seconds);
            }
            else
            {
                timerText.text = string.Format(@"{0}:{1}", minutes, seconds);
            }

            if (seconds == 0 && time > 1)
            {
                gameObject.GetComponent<Animator>().SetInteger("Seconds", 0);
            }
            else if (seconds != 0 && time > 1)
            {
                Invoke("ReturnToStaticAnimation", 5f);
            }
        }
        else 
        {
            if (LoadGame("Time") < Mathf.Round(time)) 
            {
                Invoke("vfxF",1f);
                SaveGame("Time", (int)Mathf.Round(time));
                sadPinguin.SetActive(false);
                smilingPpinguin.SetActive(true);
                if(TimeStringLessTen((int)Mathf.Round(time) % 60))
                    gameOverText.GetComponent<Text>().text = string.Format("New Record <color=\"#FF9000\">{0}:0{1}</color>", minutes,seconds);
                else
                    gameOverText.GetComponent<Text>().text = string.Format("New Record <color=\"#FF9000\">{0}:{1}</color>", minutes, seconds);
                gameOverText.GetComponent<Text>().color = Color.yellow;



            } 
        }
        
    }
    void ReturnToStaticAnimation() 
    {
        gameObject.GetComponent<Animator>().SetInteger("Seconds", 1);
    }
    void vfxF() 
    {
        Instantiate(vfx, new Vector3(0.1f, 1.3f, -1), Quaternion.identity);

    }

    private void SaveGame(string key, int result)
    {
        PlayerPrefs.SetInt("Time", result);
    }
    private int LoadGame(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else 
        {
            return 0;
        }
    }

    private bool TimeStringLessTen(int seconds) 
    {
        if (seconds < 10)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

