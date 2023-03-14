using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class zobie : MonoBehaviour
{   
    public GameObject body;
    public GameObject bodyPointer;
    private GameObject player;
    public int topSpeed;
    public int followSpeed;
    public Rigidbody Enime;
    public CapsuleCollider boxCollider; 
    private ParticleSystem particlesistem;
    private bool alive = true;
    private Vector3 flatVel;
    public int health = 4; 
    public int jumpMultiplyer = 10;
    public GameObject coneColider;
    private bool jumpReaddy;
    void Start()
    {
        particlesistem = GetComponent<ParticleSystem>();
        player = GameObject.Find("/newPlayer/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {   
        SpeedControl();
        if(alive == false){
            if(particlesistem.isPlaying == false){
            Destroy(gameObject);
        }
       }
        if(health <= 0 && alive == true){
            die();
        }
    }
    private void FixedUpdate() {
        move();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            health -= 1;
        }
    }
    private void OnTriggerEnter(Collider other){
        Debug.Log("trigger hit");
        if(other.gameObject.tag == ("Player")){
            Debug.Log("read player");
            if(jumpReaddy == true){
            Debug.Log("jump ready");
            jump();
            jumpReaddy = false;
            }
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == ("Player")){
            jumpReaddy = true;
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
        Destroy(boxCollider);
    }
    private void move(){
        if(alive == true){
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y ,player.transform.position.z));
        Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
       }
    }
    private void jump(){
        Enime.AddForce(new Vector3(0,jumpMultiplyer * player.transform.position.y,0));
    }
    private void SpeedControl()
   {
       flatVel = new Vector3(Enime.velocity.x, 0f, Enime.velocity.z);
       if(flatVel.magnitude > topSpeed)
       {
           Vector3 limitedVel = flatVel.normalized * topSpeed;
           Enime.velocity = new Vector3(limitedVel.x, Enime.velocity.y, limitedVel.z);
       }
   }

}
