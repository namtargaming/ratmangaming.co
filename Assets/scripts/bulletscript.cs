using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour{ 

    private Rigidbody bullet;
    public int bulletspeed = 100;
    public float bulletLifeTime = 10.0f;
    private float I = 1.0f;
    private GameObject Player;
    private Rigidbody PlayerRgidbody;
    private Vector3 bulletVelosity;
    private Vector3 corectPlayerVelosity;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("/player");

        bullet = GetComponent<Rigidbody>();

        PlayerRgidbody = Player.GetComponent<Rigidbody>();

        corectPlayerVelosity = new Vector3(PlayerRgidbody.velocity.x, PlayerRgidbody.velocity.z, PlayerRgidbody.velocity.y * -1 ) * 49.9f;

        bulletVelosity = new Vector3(0,bulletspeed,0) + corectPlayerVelosity;

        bullet.AddForce(transform.rotation * bulletVelosity);

        Debug.Log(PlayerRgidbody.velocity);

    }
    // Update is called once per frame
    void Update()
    {
        if(bulletLifeTime >= I ){
            I += 1.0f * Time.deltaTime;
        }
        else{
            Kill();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != ("Player")){
            Kill();
        }   
    }
    private void Kill(){
        Destroy(gameObject);
    }
}
