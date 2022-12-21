using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderTutorial : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogtext;
    public string message;
    // Start is called before the first frame update


    public void ActivatePanel()
    {
       dialogPanel.SetActive(true);
       dialogtext.text = message;
       StartCoroutine(TextDesactivate());
    }


    public void ClosePanel()
    {
        StartCoroutine(TextDesactivate());
    }

    IEnumerator TextDesactivate()
    {
        yield return new WaitForSeconds(2f);
        dialogPanel.SetActive(false);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ActivatePanel();
        GetComponent<Collider2D>().isTrigger = true;
        
    }

}
