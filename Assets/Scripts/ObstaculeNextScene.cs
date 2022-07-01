using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculeNextScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletSpecial"))
        {
            if (NewScene.instance)
            {
                NewScene.instance.check = true;
            }
           
            Destroy(gameObject);
        }
    }
}
