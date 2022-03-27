using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool rewardtaken=false;
    [SerializeField] AudioSource Audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0,0,-2000 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0,0,2000 * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Play again");
        }

        if (other.gameObject.tag == "Collectable")
        {
            Audio.Play();
            Destroy(other.gameObject);
            rewardtaken=true;
        }
            
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "BackToStart") && (rewardtaken==true))
        {
            Debug.Log("You won");
            SceneManager.LoadScene("Play again");
        }

    }
}
