using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNewAttack4 : IState
{
    FiniteStateMachine _fsm;
    BossNew _bossNew;

    float cronometro = 0;
    float tiempoFinal;


    public BossNewAttack4(FiniteStateMachine fsm, BossNew bossNew)
    {
        _fsm = fsm;
        _bossNew = bossNew;

    }


    public void OnStart()
    {
        tiempoFinal = Random.Range(10f, 18f);
        _bossNew.init3.SetActive(true);
        _bossNew.init4.SetActive(true);
        _bossNew.init5.SetActive(true);
        _bossNew.init6.SetActive(true);

    }

    public void OnUpdate()
    {
        Attack4Behaivor();

    }

    public void OnExit()
    {
        _bossNew.mySprite.color = Color.white;
    }

    public void Attack4Behaivor()
    {
        _bossNew.mySprite.color = Color.red;

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            cronometro = 0;
            _fsm.ChangeState(BossNewStates.Idle);
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