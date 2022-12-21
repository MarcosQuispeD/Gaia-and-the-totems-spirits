using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewPatrol1 : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;
    float cronometro = 0;
    float tiempoFinal;


    public BossNewPatrol1(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;
    }

    public void OnStart()
    {
        tiempoFinal = Random.Range(10f, 18f);
        //Debug.Log(tiempoFinal);

    }

    public void OnUpdate()
    {
        Patrol1Behaivor();
    }

    public void OnExit()
    {
        _bossNew.mySprite.color = Color.white;

    }

    public void Patrol1Behaivor()
    {
        _bossNew.mySprite.color = Color.red;

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            cronometro = 0;
            if (_bossNew.level == 1)
            {
                _fsm.ChangeState(BossNewStates.Attack1);
            }
            if (_bossNew.level == 2)
            {
                _fsm.ChangeState(BossNewStates.Attack3);
            }

        }
        _bossNew.transform.position = Vector2.MoveTowards(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position, _bossNew.speed * Time.deltaTime);

        if (Vector2.Distance(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position) < _bossNew.distance)
        {
            _bossNew.nextPoint = _bossNew.nextPoint + 1;
            if (_bossNew.nextPoint > 4)
            {
                _bossNew.nextPoint = 0;
            }


        }


    }


}
