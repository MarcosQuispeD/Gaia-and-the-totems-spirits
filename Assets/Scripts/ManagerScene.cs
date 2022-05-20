using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

    public static ManagerScene instance;
    public int scene;
    public bool check;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCollider"))
        {

            if (scene == 2 && check)
            {
                SceneManager.LoadScene(scene);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
      
    }
}
