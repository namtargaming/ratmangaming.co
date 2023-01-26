using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerControlls : MonoBehaviour
{
    public int JumpHight = 10;
    public bool OnFloor = true;
    private Rigidbody player;
    [SerializeField]
    private InputActionReference jumpButoon;

    private void Start() {
        player = GetComponent<Rigidbody>();
        Debug.Log("start");
    }

    void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.tag == "florr")
     {
        OnFloor = true;
     }
    }
    private void OnEnable() {
        jumpButoon.action.performed += jumping;
        Debug.Log("onenable");
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
        Debug.Log("ondisable");
    }

    private void jumping(InputAction.CallbackContext obj){
        if(OnFloor){
            jump();
          Debug.Log("called jump");
        }
    }

//    private void slide(InputAction.CallbackContext obj){
//        if(OnFloor){
//
//        }
//    }

    public void jump() {
        player.AddForce(0,JumpHight,0);
        Debug.Log("jumping");
        OnFloor = false;
    }

//    public void slide() {
//
//    }
}