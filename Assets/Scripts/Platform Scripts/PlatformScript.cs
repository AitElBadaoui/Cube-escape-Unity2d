﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        if (is_Breakable)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            //Destroy Platform
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject()
    {
        //TO-DO : IceBreakSound()
        gameObject.SetActive(false);

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                //TO-DO : GameOver() + Restart();


            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable)
            {

                //TO-DO : LandSound();`
                animator.Play("Break");

            }
            if (is_Platform)
            {
                //TO-DO : LandSound();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);

            }
            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);

            }
        }
    }
}
