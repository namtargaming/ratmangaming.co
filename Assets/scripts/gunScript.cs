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
    private Animator anim;
    private AudioSource audioData;
    public AudioClip ShootSound;
    public AudioClip ReloadSound;
    public LineRenderer Line;
    [SerializeField]
    private InputActionReference Shootbutton, reloadbutton;

    private void Start() {
        anim = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
    }
    private void Update() {
        rotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.right);
        Line.SetPosition(0, transform.position + transform.forward*0.1f);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                Line.SetPosition(1, hit.point);
            }
        }
        else Line.SetPosition(1, transform.forward*500000);
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
        if(amo >= 0) 
        {
            shoot();
        }
    }

    private void reloadGun(InputAction.CallbackContext obj){
        if(amo <= 17){
            relode();
        }
    }

    public void shoot() {
    Instantiate(bullet, new Vector3(transform.position.x , transform.position.y + 0.0489f,transform.position.z), rotation);
    Instantiate(bulletCasing, transform.position + new Vector3(0,1,0) * 0.05f, rotation);
    anim.Play("Base Layer.Scene", 0 ,0.0f);
    audioData.PlayOneShot(ShootSound,1.0f);
    amo -= 1;
    }

    public void relode() {
        audioData.PlayOneShot(ReloadSound,1.0f);
        anim.Play("Base Layer.gun flip", 0 ,0.0f);
        amo = 17;
    }

}