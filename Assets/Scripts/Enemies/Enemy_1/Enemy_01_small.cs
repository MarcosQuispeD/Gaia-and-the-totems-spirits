using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01_small : Entity_enemy
{
    public override void Start()
    {
        base.Start();
        _life = 1;
    }

    public override void Update()
    {
        base.Update();
        Follow(_player);
    }

   
}
