using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{

    public float xMin, xMax, zMin, zMax;
    }

public class PlayerControler : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float driftExcursion;
    
    private Rigidbody rb;
    private float nextFire;
    private AudioSource playerAudio;
     
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {


        //Instantiate(shot, shotSpanw.position, shotSpanw.rotation);//

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //newProjectile = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);//as GameObject;
            playerAudio.Play();

            // create code here that animates the newProjectile

        }
    }
    
    // once per physics step
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveDrift = Input.GetAxis("Rotation");

        //Debug.Log(moveDrift);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        

        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, moveDrift * driftExcursion, rb.velocity.x * -tilt);
        //// Add in code
        //if (Input.GetButton("q"))
        //{
        //        rb.rotation = Quaternion.Euler(0*/)
        //    rb.rotation = Quaternion.Euler(0.0f, rb.velocity.x * tilt, 0.0f);
        //}


    }
}
