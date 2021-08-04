using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fishPrefab;

    // Start is called before the first frame update
    void Start()
    {
        createFish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createFish()
    {
        GameObject fish = Instantiate(fishPrefab);

        bool rightFish = Random.Range(0,2) == 1;

        float y = Random.Range(-4.59f, 0f);
        float x;

        if (rightFish)
        {
            x = 11;
            fish.GetComponent<Fish>().movement.x = -0.4f;
        } else
        {
            x = -11;
            fish.GetComponent<Fish>().movement.x = 0.4f;
        }

        fish.GetComponent<Transform>().position = new Vector3(x,y,1);
    }
}
