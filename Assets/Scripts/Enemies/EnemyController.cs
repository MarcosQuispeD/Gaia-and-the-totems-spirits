using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField]
    protected float life, damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetLifeEnemy()
    {
        return life;
    }

    public void SetLifeEnemy(float life)
    {
        this.life = life;
    }

}
