using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Anim_Controller : MonoBehaviour
{
    Animator _anim;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        Debug.Log("Teclas para verificar animaciones: QWERTY");
    }

    void Update()
    {
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
}
