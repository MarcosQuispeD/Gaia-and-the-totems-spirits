using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_enemy : MonoBehaviour
{
    protected GameObject _player;
    protected int _speed = 3;
    public int _life;
    private AudioSource _myAudioSource;
    private SpriteRenderer _mySprite;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        //No lo agrego desde el proyecto, porque el prefab no me lo permite 
       _player = GameObject.FindWithTag("Player");
       _myAudioSource = GetComponent<AudioSource>();
       _mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (_life < 1)
        {
        Destroy(gameObject);
        }

    }
    
    public void Damage(int power)
    {
        //Aca podemos restar vida, podemos llamar a una animacion y podemos lanzar una respuesta.
        _life = _life - power;
        StartCoroutine(Feedback());
  
    }

    public void Follow(GameObject player)
    {
    transform.position = Vector3.MoveTowards( transform.position, _player.transform.position, _speed * Time.deltaTime);
    }


    public void Spawn_childs(GameObject small_child)
    { 
        //Cada vez que es atacado, suelta 2 enemigos.
        Vector3 _position = new Vector3 (transform.position.x -1, transform.position.y -1, transform.position.z);
        GameObject enemy_child = Instantiate(small_child, _position , transform.rotation );
        _position = new Vector3 (transform.position.x +1, transform.position.y -1, transform.position.z);
        enemy_child = Instantiate(small_child, _position , transform.rotation );
    }


    public virtual void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _myAudioSource.Play();
            Damage(1);
        }
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
       
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
       
    }

    public IEnumerator Feedback()
    {
        _mySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _mySprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _mySprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _mySprite.color = Color.white;
    }



}
