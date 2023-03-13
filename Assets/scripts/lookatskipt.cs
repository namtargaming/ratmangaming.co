using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatskipt : MonoBehaviour
{
    private GameObject player;


    // Update is called once per frame
     void Start()
    {
        player = GameObject.Find("/newPlayer/Main Camera");
    }
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
