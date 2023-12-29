using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Animator anim;

    public PlayerMovement player;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x == 0f && y == 0f)
        {
            anim.SetBool("Breathe", true);
            anim.SetBool("Sprint", false);
            anim.SetBool("Walk", false);
        }
        else
        {
            if(player.isWalking == false)
            {
                anim.SetBool("Breathe", false);
                anim.SetBool("Sprint", true);
                anim.SetBool("Walk", false);
            }
            if(player.isWalking == true)
            {
                anim.SetBool("Breathe", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("Walk", true);
            }
        }
    }
}
