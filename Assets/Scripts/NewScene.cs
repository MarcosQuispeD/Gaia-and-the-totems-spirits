using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public static NewScene instance;
    public int scene;
    public bool check;
    public GameObject BlockTree;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            Destroy(BlockTree);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && check)
        {
            check = false;
            Debug.Log(collision.gameObject.GetComponentInParent<PlayerStats>().currentHealth);
            PlayerPrefs.SetInt("Life", collision.gameObject.GetComponentInParent<PlayerStats>().currentHealth);
            if (scene == 0)
            {
                ManagerScene.instance.DestroyObject();
            }
            else
            {
                PlayerPrefs.SetInt("Life", collision.gameObject.GetComponentInParent<PlayerStats>().currentHealth);
            }
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.Log("Collision");
        }
    }
}
