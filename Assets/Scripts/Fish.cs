using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movespeed = 15f;

    public Vector2 movment;
    public GameObject effect;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * movespeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Hook" && gameObject.tag !="Shark")
        {

            collision.gameObject.GetComponent<Hook>().catchFish(gameObject);
        }
        if (collision.gameObject.tag == "Hook" && gameObject.tag == "Shark" && collision.gameObject.GetComponent<Hook>().catchfishing == true)
        {
            GameObject.Find("Fill").GetComponent<Animator>().SetBool("Attacked", true);
            //fill.GetComponent<Animator>().SetInteger("Attacked", 1);
            Invoke("FillStatic", 1f);
            GameObject partical = Instantiate(effect, collision.transform.GetChild(1).transform.position, Quaternion.identity);
            Destroy(partical, 5f);
            collision.gameObject.GetComponent<Hook>().catchfishing = false;
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        
        }
        if (collision.gameObject.tag == "Fish" && gameObject.tag == "Shark")
        {
            GameObject partical = Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(partical, 5f);            
            Destroy(collision.gameObject);
        }


    }
    void FillStatic()
    {
        GameObject.Find("Fill").GetComponent<Animator>().SetBool("Attacked", false);
        //fill.GetComponent<Animator>().SetInteger("Attacked", 0);
    }
}
