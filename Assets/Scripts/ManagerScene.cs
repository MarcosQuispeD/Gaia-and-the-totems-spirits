using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

    public static ManagerScene instance;

    protected float live;
    protected float ligth;
    protected float sideLigth;
    public bool isInnitGame;
    void Awake()
    {
        if (instance == null)
        {
            isInnitGame = true;
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
   


   

}
