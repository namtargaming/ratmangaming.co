using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{

    private void Update() {
        Ray bulletPath = gunparent.position transform.TransformDirection(Vector3.forward);
    }
    public void shoot() {
    Debug.Log("BANG!!!");
    }

    public void relode() {
        Debug.Log("relaoduing");
    }
}
