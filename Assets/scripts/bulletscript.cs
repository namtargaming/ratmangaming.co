using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour{ 

    private Rigidbody bullet;
    public int bulletspeed = 100;
    public float bulletLifeTime = 10.0f;
    private float I = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();

        bullet.AddForce(transform.rotation * new Vector3(0,bulletspeed,0));

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
