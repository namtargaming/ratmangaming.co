using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class enime : MonoBehaviour
{
    public Transform player;
    public int topSpeed = 100;
    public int followSpeed = 100;
    public Rigidbody Enime;       
    private float velosity;
    // Start is called before the first frame update

        private void Awake()
    {
//        player = GameObject.Find("player").transform;
    }
    void Start()
    {
    //    Enime = GetComponent<Rigidbody>();
        velosity = Enime.velocity.x * Enime.velocity.y * Enime.velocity.z / 3; 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(velosity);
        //Debug.Log(Enime.velocity.x);
        //Debug.Log(Enime.velocity.z);
        //Debug.Log(Enime.velocity.y);
//
        //transform.LookAt(player.position);
        //if(velosity <= topSpeed){
        //Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            Destroy(gameObject);
        }
    }
}
