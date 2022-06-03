using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01_small : Entity_enemy
{
    public float toFarDistance;
    public float toCloseDistance;

    public override void Start()
    {
        base.Start();
        _life = 1;
    }

    public override void Update()
    {
        base.Update();
        
        if (Vector3.Distance(transform.position, _player.transform.position) < toFarDistance && Vector3.Distance(transform.position, _player.transform.position) > toCloseDistance )
        {
            Follow(_player);
        }
        else
        {
            
        }
       
    }

   
}
