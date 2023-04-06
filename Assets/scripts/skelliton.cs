using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class skelliton : MonoBehaviour
{   
    public GameObject body;
    private GameObject player;
    public int topSpeed;
    public int followSpeed;
    public Rigidbody Enime;
    public BoxCollider boxCollider; 
    private ParticleSystem particlesistem;
    private bool alive = true;
    private Vector3 flatVel;
 //   public Animator anim;
    private score scoreboardScript; 
    private GameObject scoreboardObject;
    void Start()
    {

        scoreboardObject = GameObject.Find("/score");
        scoreboardScript = scoreboardObject.GetComponent<score>();
        particlesistem = GetComponent<ParticleSystem>();
        player = GameObject.Find("newPlayer/Main Camera");
        
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
 //      anim.Play("Base Layer.skull movement", 0 ,0.0f);
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
        scoreboardScript.playerScore += 10;
        particlesistem.Play();
        alive = false;
        Destroy(body);
        Enime.drag = 10;
        Enime.freezeRotation = true;
        Enime.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        Destroy(boxCollider);
    }
    private void move(){
        if(alive == true){
        transform.LookAt(player.transform.position);
        Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
       }
    }
    private void SpeedControl()
   {
       flatVel = new Vector3(Enime.velocity.x, Enime.velocity.y, Enime.velocity.z);
       if(flatVel.magnitude > topSpeed)
       {
           Vector3 limitedVel = flatVel.normalized * topSpeed;
           Enime.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);
       }
   }

}
