using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Anim_Controller : MonoBehaviour
{
    Animator _anim;
    //public GameObject bala_prefab;
    public bool flip;

    
    void Start()
    {
        _anim = GetComponent<Animator>();
        Debug.Log("Teclas para verificar animaciones: QWERTY");
    }

    void Update()
    {
        flip = GetComponent<SpriteRenderer>().flipX;
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Disparando");
            _anim.Play("Attack");
            //SpawnBala();   
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q: WALK");            
            _anim.Play("Walk");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W: Damage");
            _anim.Play("Damage");
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E: Dash ");
            _anim.Play("Dash");
        }

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("R: Death");
            _anim.Play("Death");
        }

        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T: Fall");
            _anim.Play("Fall");
        }

        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("Y: Jump");
            _anim.Play("Jump");
        }

        
    }

    //  public void SpawnBala()
    //   {
    //      GameObject bala_instanciada = Instantiate(bala_prefab, transform.position , transform.rotation );
    //      bala_instanciada.GetComponent<Bala_Test>().Movement(flip, 1);

    //   }


}
