using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enime : MonoBehaviour
{   
    public GameObject body;
    public GameObject bodyPointer;
    public Transform player;
    public int topSpeed;
    public int followSpeed;
    public Rigidbody Enime;
    public BoxCollider collider; 
    private ParticleSystem particlesistem;
    private bool alive = true;
    void Start()
    {
        particlesistem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(alive == false){
            if(particlesistem.isPlaying == false){
            Destroy(gameObject);
        }
       }
    }
    private void FixedUpdate() {
        move();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            die();
        }
    }
    private void die(){
        particlesistem.Play();
        alive = false;
        Destroy(body);
        Destroy(bodyPointer);
        Enime.drag = 10;
        Enime.freezeRotation = true;
        Enime.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        Destroy(collider);
    }
    private void move(){
        if(alive == true){
        transform.LookAt(player.position);
        Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
       }
    }

}
