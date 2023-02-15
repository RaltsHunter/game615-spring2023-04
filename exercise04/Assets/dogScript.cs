using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dogScript : MonoBehaviour
{
    //Players have 60 seconds to collect 7 tennis balls.
    public GameObject player;
    public GameObject projectile;
    float forwardSpeed = 5f;
    float rotateSpeed = 100f;
    public float timeR = 45;
    public float ballsGotten = 0;
    public TMP_Text ballCount;
    public TMP_Text timeCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //flying + controls
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);
        gameObject.transform.Translate(transform.forward * forwardSpeed * Time.deltaTime, Space.World);
        //Timer
        timeR = 45 - Time.time;
        timeCount.text = timeR.ToString();

        //victory condition
        if (ballsGotten == 7)
        {
            ballCount.text = "Victory!";
        }
        //lose condition
        if (timeR <= 0)
        {
            timeCount.text = "Game Over!";
            Destroy(player);
        }
        //Bullet launch
       // if (Input.GetKeyDown(KeyCode.Space))
       // {
        //    {
               // GameObject.Find(player);
           //     GameObject bullet = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            //    Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //    rb.AddForce(bullet.transform.forward * 1000);

                //Destroy(projectile, 2f);
       //     }

      //  }


    }

    private void OnTriggerEnter(Collider other)
   {
        //hitting good things
      if (other.CompareTag("ball"))
       {
          Destroy(other.gameObject);
            ballsGotten = ballsGotten + 1;
            ballCount.text = ballsGotten.ToString();


        }
        
      //hitting bad things
     if (other.CompareTag("other"))
        {
            //Destroy(player.gameObject);
            player.transform.position = new Vector3(3, 5.02f, 3.01f);
            player.transform.rotation = Quaternion.identity;
       }
    }

   }
