using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewAttack2 : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;

    float cronometro = 0;
    float tiempoFinal;


    public BossNewAttack2(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }

    public void OnStart()
    {
        tiempoFinal = Random.Range(10f, 18f);
        _bossNew.init2.SetActive(true);
        _bossNew.nextPoint = 5;

    }

    public void OnUpdate()
    {
        Attack2Behaivor();

    }

    public void OnExit()
    {

    }

    public void Attack2Behaivor()
    {

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            cronometro = 0;
            _fsm.ChangeState(BossNewStates.Idle);
        }
        _bossNew.transform.position = Vector2.MoveTowards(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position, _bossNew.speed * Time.deltaTime);

        if (Vector2.Distance(_bossNew.transform.position, _bossNew.wayPoints[_bossNew.nextPoint].transform.position) < _bossNew.distance)
        {
            _bossNew.nextPoint = _bossNew.nextPoint +1;

            if (_bossNew.nextPoint == 7)
            {
                _bossNew.nextPoint = 5;
            }

        }



    }


}