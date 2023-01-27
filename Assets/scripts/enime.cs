using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class enime : MonoBehaviour
{
    public Transform player;
    public int topSpeed = 100;
    public Rigidbody Enime;       
    private Vector3 velosity;
    // Start is called before the first frame update

        private void Awake()
    {
//        player = GameObject.Find("player").transform;
    }
    void Start()
    {
    //    Enime = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
//        if(velosity >= new Vector3(topSpeed,topSpeed,topSpeed))
        Enime.AddForce(transform.rotation * new Vector3(0,0,topSpeed));
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            Destroy(gameObject);
        }
    }
}
