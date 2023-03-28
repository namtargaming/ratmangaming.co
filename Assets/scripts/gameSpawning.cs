using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSpawning : MonoBehaviour
{
    private Animator anim;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Base Layer.gamespawning", 0 ,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += 1f * Time.deltaTime;
    }
    

}
