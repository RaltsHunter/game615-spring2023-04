using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour
{
    //Players have 60 seconds to collect 7 tennis balls.
    public GameObject player;
    float forwardSpeed = 5f;
    float rotateSpeed = 100f;
    public float timeR = 60;
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
        timeR = 60 - Time.time;
        timeCount.text = timeR;

        //victory condition
        if (ballsGotten == 7)
        {
            ballCount.text = "Victory!";
        }
        //lose condition
        if (timeR == 0)
        {
            timeCount.text = "Game Over!";
        }


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