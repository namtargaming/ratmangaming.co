using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class gunScript : MonoBehaviour
{
    public int bulletSpeed = 10;
    public int reloadTime = 10;
    public bool sideLT_RF = true;
    public GameObject bullet;
    public GameObject bulletCasing;
    private Quaternion rotation;
    [SerializeField]
    private InputActionReference shootR, shootL, reloadR, reloadL;

    private void Update() {
        rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.right);
    }

    private void OnEnable() {
        shootL.action.performed += ShootGun;
        shootR.action.performed += ShootGun;
    }
    
    private void OnDisable() {
        shootL.action.performed -= ShootGun;
        shootR.action.performed -= ShootGun;
    }

    private void ShootGun(InputAction.CallbackContext obj){
        if(sideLT_RF == false){
            shoot();
        }
        if(sideLT_RF == true){
            shoot2();
        }
    }

    public void shoot() {
    Instantiate(bullet, transform.position, rotation);
    Instantiate(bulletCasing, transform.position, rotation);

    }

    public void relode() {

    }

   public void shoot2() {
   Debug.Log("BANG!!!");
   Instantiate(bullet, transform.position, rotation);
   Instantiate(bulletCasing, transform.position, rotation);
   }

   public void relodeL () {

   }
}
