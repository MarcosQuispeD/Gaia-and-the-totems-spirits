using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewAttack1 : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;

    float cronometro = 0;
    float tiempoFinal;


    public BossNewAttack1(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }

    public void OnStart()
    {
        tiempoFinal = Random.Range(10f, 18f);
        _bossNew.init1.SetActive(true);
    }

    public void OnUpdate()
    {
        Attack1Behaivor();

    }

    public void OnExit()
    {

    }

    public void Attack1Behaivor()
    {
        
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            cronometro = 0;
            _fsm.ChangeState(BossNewStates.Attack2);
        }
        _bossNew.transform.position = Vector2.MoveTowards(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position, _bossNew.speed * Time.deltaTime);

        if (Vector2.Distance(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position) < _bossNew.distance)
        {
            _bossNew.nextPoint = _bossNew.nextPoint + 3;
            if (_bossNew.nextPoint > 4)
            {
                _bossNew.nextPoint = 1;
            }

        }


    }


}
