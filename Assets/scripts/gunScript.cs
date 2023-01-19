using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{
    bool isShooting = false;
    private InputAction shootAction;

    private void Awake() {
        if (shootAction.performed){
            isShooting = true;
        }      
    }
    private void Update() {
        if (isShooting == true){
            void shooting();
        }
        
    }

    private void shooting(){
        Debug.Log("shooting");
    }

}
