using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewIdle : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;
    float cronometro = 0;


    public BossNewIdle(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }

    public void OnStart()
    {
        _bossNew._centre = _bossNew.transform.position;
        _bossNew.bossCurrentLife = _bossNew.bossMaxLife;
        _bossNew.CurrentTimeChanger = _bossNew.stateChanger;
        _bossNew.init.SetActive(false);


    }

    public void OnUpdate()
    {
        IdleBehaivor();

    }

    public void OnExit()
    {

    }

    public void IdleBehaivor()
    {
        var offset = new Vector2(Mathf.Sin(_bossNew._angle), Mathf.Cos(_bossNew._angle)) * _bossNew.Radius;
        _bossNew.transform.position = _bossNew._centre + offset;
        _bossNew._angle += _bossNew.RotateSpeed * Time.deltaTime;
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            cronometro = 0;
            _fsm.ChangeState(BossNewStates.Patrol1);
        }

    }

}
