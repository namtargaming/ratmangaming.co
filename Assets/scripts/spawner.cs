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
        transform.LookAt( new Vector3(player.transform.position.x ,transform.position.y + 1 ,player.transform.position.z));
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == ("playerBullet")){
            Instantiate(spawnEtity, spawnPoint.position, new Quaternion(0,0,0,0));
        }
    }
}
