using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    public Animator camAnim;
    public GameObject effect01;
    public GameObject gameover;

    ActType act_cur = ActType.idle; 
    float act_time = 0.0f;

    bool jumpCheck;
    public bool pScore=false;
    public enum ActType
    {
        idle,
        gravityJump,    
        death
    }
    void Start()
    {
        jumpCheck = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumpCheck = true;
            camAnim.SetTrigger("shake");
            Instantiate(effect01, transform.localPosition, Quaternion.identity);
            pScore = true;
        }

        if (collision.transform.tag == "Obstacle01")
        {
            gameover.gameObject.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && jumpCheck == true)
        {
            Rigidbody2D.gravityScale = Rigidbody2D.gravityScale * -1;
            jumpCheck = false;
            print("!");
           
        }
    }

    void ActSet(ActType act)
    {
        act_cur = act;
        switch (act_cur)
        {
            case ActType.idle:
                {
                    //animator.Play("walk");
                }
                break;
            case ActType.gravityJump:
                {
                    act_time = Time.time + 2f;
                    //animator.Play("jump1");
                }
                break;
            case ActType.death:
                {
                    act_time = Time.time + 1.0f;
                    //animator.Play("death");
                }
                break;
            default:
                break;
        }
    }

    void ActUpdate()
    {
        switch (act_cur)
        {
            case ActType.idle:
                break;
            case ActType.gravityJump:
                {
                    if (Time.time > act_time)
                        ActSet(ActType.idle);
                }
                break;
            case ActType.death:
                {
                    if (Time.time > act_time)
                    {
                        //game over
                    }
                }
                break;
            default:
                break;
        }
    }
}
