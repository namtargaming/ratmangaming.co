using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{
    public int bulletSpeed = 10;
    public int reloadTime = 10;
    public GameObject bullet;
    public void shoot() {
        Debug.Log("BANG!!!");
        Instantiate(bullet, transform, true);
    }

    public void relode() {
        Debug.Log("relaoduing");
    }
}
