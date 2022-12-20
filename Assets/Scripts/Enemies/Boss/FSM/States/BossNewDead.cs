using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewDead : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;


    public BossNewDead(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }

    public void OnStart()
    {

    }

    public void OnUpdate()
    {


    }

    public void OnExit()
    {

    }

    public void Patrol1Behaivor()
    {


    }


}