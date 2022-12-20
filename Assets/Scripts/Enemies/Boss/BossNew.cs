using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossNewStates
{
    Idle,
    Patrol1,
    Patrol2,
    Attack1,
    Attack2,
    Attack3,
    Attack4,
    Dead
}

public class BossNew : MonoBehaviour
{
    public FiniteStateMachine _FSM;

    public List<Transform> wayPoints = new List<Transform>();
    public int nextPoint = 1;
    public int speed;
    public float distance = 0.1f;

    public Collider2D colliderAttack;

    public GameObject startVFX;
    public GameObject endVFX;

    Animator myAnimator;
    private AudioSource _myAudioSource;
    public float stateChanger;
    public float CurrentTimeChanger;

    //Boss Base
    public float RotateSpeed = 2.5f;
    public float Radius = 0.25f;
    public float bossMaxLife = 100;
    public float bossCurrentLife = 0;

    public Vector2 _centre;
    public float _angle;

    public Transform gaia;
    public float shootCount = 3;
    public int rayDamage = 5;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    //Boss Ray//
    //public LineRenderer lineRenderer;
    //public Transform firePoint;

    //Otros//
    //public BossState state;
    //public Vector3 forward;
    //PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        _FSM = new FiniteStateMachine();
        var idle = new BossNewIdle(_FSM, this);
        _FSM.AddState(BossNewStates.Idle, idle);
        _FSM.AddState(BossNewStates.Patrol1, new BossNewPatrol1(_FSM, this));
        _FSM.AddState(BossNewStates.Patrol2, new BossNewPatrol2(_FSM, this));
        _FSM.AddState(BossNewStates.Attack1, new BossNewAttack1(_FSM, this));
        _FSM.AddState(BossNewStates.Attack2, new BossNewAttack2(_FSM, this));
        _FSM.AddState(BossNewStates.Attack3, new BossNewAttack3(_FSM, this));
        _FSM.AddState(BossNewStates.Attack4, new BossNewAttack4(_FSM, this));
        _FSM.AddState(BossNewStates.Dead, new BossNewDead(_FSM, this));
        _FSM.ChangeState(BossNewStates.Idle);

        FillLists();
        myAnimator = GetComponent<Animator>();


        // _centre = transform.position;
        // bossCurrentLife = bossMaxLife;
        // CurrentTimeChanger = stateChanger;

    }

    // Update is called once per frame
    void Update()
    {
        // var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        // transform.position = _centre + offset;
        // _angle += RotateSpeed * Time.deltaTime;
        _FSM.Update();
        CurrentTimeChanger -= Time.deltaTime;
        shootCount -= Time.deltaTime;
        _angle += RotateSpeed * Time.deltaTime;

    }

    void FillLists()
    {
        for (int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);

        }

        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);

        }
    }


    public IEnumerator Attacking()
    {

        yield return new WaitForSeconds(3f);
        colliderAttack.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bossCurrentLife -= 5;
        }
    }





}
