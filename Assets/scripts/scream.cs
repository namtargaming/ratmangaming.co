using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class scream : MonoBehaviour
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
    public int health = 15; 
    private bool OnFloor;
    public LayerMask whatIsGround;
    private score scoreboardScript; 
    private GameObject scoreboardObject;
    void Start()
    {
        scoreboardObject = GameObject.Find("/score");
        scoreboardScript = scoreboardObject.GetComponent<score>();
        particlesistem = GetComponent<ParticleSystem>();
        player = GameObject.Find("/newPlayer/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {   
        OnFloor = Physics.Raycast(new Vector3(transform.position.x,transform.position.y + 1 ,transform.position.z), Vector3.down, 3, whatIsGround);
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

    private void die(){
        scoreboardScript.playerScore += 60;
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
        if(alive == true  && OnFloor == true){
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y ,player.transform.position.z));
        Enime.AddForce(transform.rotation * new Vector3(0,0,followSpeed));
       }
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
