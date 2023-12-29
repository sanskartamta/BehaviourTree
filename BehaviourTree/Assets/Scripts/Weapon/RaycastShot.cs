using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastShot : MonoBehaviour
{
    public Camera PlayerCamera;

    public float FireRate = 10f;
    private float timeBetweenNextShot;
    public float Damage = 20f;

    public MouseLook mouse;

    [Header("Recoil")]
    public float vRecoil = 1f;
    public float hRecoil = 1f;

    //this is ammo area
    [Header("Ammo Management")]

    public int ammocount = 25;

    public int availableammo = 100;

    public float reloadTime;
    public int maxAmmo = 25;

    public Animator anim;
    public TextMeshProUGUI currentammotext;

    void Update()
    {
        currentammotext.text= ammocount.ToString();
        if(Input.GetKeyDown(KeyCode.R) && ammocount <= maxAmmo)
        {
            mouse.AddRecoil(0, 0);
            anim.SetBool("Reload",true);
            anim.SetBool("Shoot", false);
        }
        if(ammocount <= 0)
        {
            mouse.AddRecoil(0, 0);
            anim.SetBool("Reload", true);
            anim.SetBool("Shoot", false);
            return;
        }
        if (Input.GetButton("Fire1")&& Time.time >= timeBetweenNextShot)
        {
            timeBetweenNextShot = Time.time + 1f/FireRate;
            float h = Random.Range(-hRecoil, hRecoil);
            anim.SetBool("Shoot", true);
            mouse.AddRecoil(h , vRecoil);
            weapon();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            mouse.AddRecoil(0, 0);
            anim.SetBool("Shoot", false);
        }
           


        
    }

    void weapon()
    {
        ammocount--;
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                Health enemy = hit.transform.GetComponent<Health>();
                enemy.Damage(Damage);
            }


        }

    }

    public void Reload()
    {
        mouse.AddRecoil(0, 0);
        
        availableammo = availableammo - maxAmmo + ammocount;
        ammocount = maxAmmo;
        anim.SetBool("Reload", false);
    }
}
