using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fishPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createFish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator createFish()
    {

        yield return new WaitForSeconds(Random.Range(1f, 4f));

        GameObject fish = Instantiate(fishPrefab);

        bool rightFish = Random.Range(0,2) == 1;

        float y = Random.Range(-4.59f, 0f);
        float x;

        if (rightFish)
        {
            x = 11;
            fish.GetComponent<Fish>().movement.x = -0.1f;
            fish.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        } else
        {
            x = -11;
            fish.GetComponent<Fish>().movement.x = 0.1f;
        }

        fish.GetComponent<Transform>().position = new Vector3(x,y,1);

        StartCoroutine(createFish());
    }
}
