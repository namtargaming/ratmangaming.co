using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{
    public int bulletSpeed = 10;
    public int reloadTime = 10;
    public GameObject bullet;
    private Quaternion rotation;
    private void Update() {
        rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.right);
    }
    public void shoot() {
        Debug.Log("BANG!!!");
        Instantiate(bullet, transform.position, rotation);
    }

    public void relode() {
        Debug.Log("relaoduing");
    }
}
