using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class playerControlls : MonoBehaviour
{
    public int JumpHight = 10;
    public int health = 10;
    public bool OnFloor = true;
    private Rigidbody player;
    [SerializeField]
    private InputActionReference jumpButoon;

    private void Start() {
        player = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.tag == "florr")
     {
        OnFloor = true;
     }
     if(collision.gameObject.tag == ("enime"))
     {
        health -= 1; 
     }
    }
    private void OnEnable() {
        jumpButoon.action.performed += jumping;
    }
    
    private void OnDisable() {
        jumpButoon.action.performed -= jumping;
    }

    private void Update() {
        if(health <= 0){
            die();
        }
    }

    private void jumping(InputAction.CallbackContext obj){
        if(OnFloor){
            jump();
        }
    }

//    private void slide(InputAction.CallbackContext obj){
//        if(OnFloor){
//
//        }
//    }

    public void jump() {
        player.AddForce(0,JumpHight,0);
        OnFloor = false;
    }

//    public void slide() {
//
//    }

    public void die(){
        SceneManager.LoadScene("main");
    }
}