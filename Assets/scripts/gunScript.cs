using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{
    public int bulletSpeed = 10;
    public int reloadTime = 10;
    private int amo = 17;
    public GameObject bullet;
    public GameObject bulletCasing;
    private Quaternion rotation;
    [SerializeField]
    private InputActionReference Shootbutton, reloadbutton;

    private void Update() {
        rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.right);
    }

    private void OnEnable() {
        Shootbutton.action.performed += ShootGun;
        reloadbutton.action.performed += reloadGun;
    }
    
    private void OnDisable() {
        Shootbutton.action.performed -= ShootGun;
        reloadbutton.action.performed -= reloadGun;
    }

    private void ShootGun(InputAction.CallbackContext obj){
        if(amo >= 0){
            shoot();
      }
    }

    private void reloadGun(InputAction.CallbackContext obj){
        if(amo <= 10){
            relode();
        }
    }

    public void shoot() {
    Instantiate(bullet, transform.position, rotation);
    Instantiate(bulletCasing, transform.position, rotation);
    amo -= 1;
    }

    public void relode() {
        Debug.Log("relodeing");
        amo = 10;
    }
}