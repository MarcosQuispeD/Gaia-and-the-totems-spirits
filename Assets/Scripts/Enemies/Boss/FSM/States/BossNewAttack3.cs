using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewAttack3 : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;

    float cronometro = 0;
    float tiempoFinal;
    Vector2 target;


    public BossNewAttack3(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }

    public void OnStart()
    {
        tiempoFinal = Random.Range(10f, 18f);
        target = _bossNew.gaia.transform.position;
    }

    public void OnUpdate()
    {
        Attack3Behaivor();
    }

    public void OnExit()
    {
        _bossNew.mySprite.color = Color.white;

    }

    public void Attack3Behaivor()
    {
        _bossNew.mySprite.color = Color.red;

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            cronometro = 0;
            _fsm.ChangeState(BossNewStates.Idle);
        }
        _bossNew.transform.position = Vector2.MoveTowards(_bossNew.transform.position, target, _bossNew.speed * Time.deltaTime);

        if (Vector2.Distance(_bossNew.transform.position, target) < 5f)
        {
            target = _bossNew.wayPoints[0].transform.position;
            if (Vector2.Distance(_bossNew.transform.position, target) < 2f)
            {
                _fsm.ChangeState(BossNewStates.Idle);
            }

        }

    }

}