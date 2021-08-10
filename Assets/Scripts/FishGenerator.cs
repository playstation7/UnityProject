using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public GameObject bottlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(createFish());
        StartCoroutine(createShark(4));
        StartCoroutine(createBottle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator createFish() 
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        GameObject fish = Instantiate(fishPrefab);
        bool rightfish = Random.Range(0, 2) == 1;

        float y = Random.Range(-4f, 1.5f);
        float x;
        if (rightfish) 
        {
            x = 5;
            fish.GetComponent<Fish>().movment.x = Random.Range(-0.3f,-0.1f);
            fish.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }
        else
        {
            x = -5;
            fish.GetComponent<Fish>().movment.x =Random.Range(0.3f,0.1f);
        }
        fish.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createFish());
    }
    private IEnumerator createShark(float tSpaun)
    {
        
        if (tSpaun < 0.1) 
        {
            tSpaun = (float)0.1;
        }
        yield return new WaitForSeconds(Random.Range(Mathf.Abs(tSpaun), tSpaun+1));
        GameObject shark = Instantiate(sharkPrefab);
        bool rightfish = Random.Range(0, 2) == 1;

        float y = Random.Range(-4f, 1.5f);
        float x;
        if (rightfish)
        {
            x = 5;
            shark.GetComponent<Fish>().movment.x = Random.Range(-0.4f, -0.2f);
            
        }
        else
        {
            x = -5;
            shark.GetComponent<Fish>().movment.x = Random.Range(0.4f, 0.2f);
            shark.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }
        shark.GetComponent<Transform>().position = new Vector3(x, y, 1);
        StartCoroutine(createShark(tSpaun-0.1f));
    }
    private IEnumerator createBottle()
    {
        yield return new WaitForSeconds(50f);
        GameObject bottle = Instantiate(bottlePrefab);
        float y = Random.Range(-4f, 1.5f);
        float x;
        x = 5;
        bottle.GetComponent<Fish>().movment.x = -0.01f;
        bottle.GetComponent<Transform>().position = new Vector3(x, y, 1);
        bottle.GetComponent<Transform>().rotation = new Quaternion(bottle.GetComponent<Transform>().rotation.x, bottle.GetComponent<Transform>().rotation.y, Random.rotation.z,0);
        Destroy(bottle, 250f);
        
        StartCoroutine(createBottle());
    }
}
