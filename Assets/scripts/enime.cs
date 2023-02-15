using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
    }

    // Update is called once per frame
    void Update()
    {
        velosity = Enime.velocity.magnitude;
        Debug.Log(velosity);
        transform.LookAt(player.position);
        if(velosity <= topSpeed){
        Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
       }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            Destroy(gameObject);
        }
    }
}
