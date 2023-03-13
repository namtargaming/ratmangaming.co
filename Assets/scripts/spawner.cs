using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnEtity;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("/newPlayer/Main Camera");
    }
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            Instantiate(spawnEtity, spawnPoint.position, new Quaternion(0,0,0,0));
        }
    }
}
