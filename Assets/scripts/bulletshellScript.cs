using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletshellScript : MonoBehaviour{ 

    private Rigidbody bulletshell;
    public int bulletshellspeed = 10;
    public float bulletshellLifeTime = 10.0f;
    private float I = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        bulletshell = GetComponent<Rigidbody>();

        bulletshell.AddForce(transform.rotation * new Vector3(100,0,-bulletshellspeed));

    }
    // Update is called once per frame
    void Update()
    {
        if(bulletshellLifeTime >= I ){
            I += 1.0f * Time.deltaTime;
        }
        else{
            Kill();
        }
    }
    private void Kill(){
        Destroy(gameObject);
    }
}
