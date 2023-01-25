using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour{ 

    private Rigidbody bullet;
    public int bulletspeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();

        bullet.AddForce(transform.rotation * new Vector3(0,bulletspeed,0));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
