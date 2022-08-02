using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{

    bool isPlayerInrRange;
    bool continueDialog = false;
    bool dialogStart;
    bool isObjectDestroy;
    int lineIndex;
    [SerializeField, TextArea(4, 6)] private string[] dialegLines;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInrRange)
        {
            if (!dialogStart)
            {
                StartDialgo();
            }
        }
        else
        {
            
        }
    }

    private void StartDialgo()
    {
        dialogStart = true;
        dialogPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void ClosePanel()
    {
        dialogStart = false;
        dialogtext.text = string.Empty;
        dialogPanel.SetActive(false);
    }

    void NextDialog()
    {
        if (lineIndex == 2 && !continueDialog)
        {
            return;
        }
        else if (lineIndex == 3)
        {
            lineIndex = 5;
            continueDialog = false;
        }
        else if (lineIndex == 4)
        {
            if (dialegLines[lineIndex] == dialogtext.text)
            {
                lineIndex = 10;
            }
        }
        else if (lineIndex == 5 && !continueDialog)
        {
            return;
        }
        else if (lineIndex == 7 && continueDialog)
        {
            if (dialegLines[lineIndex] == dialogtext.text)
            {
                lineIndex = 10;
            }
        }
        else
        {
            lineIndex++;
            if (lineIndex == 7)
            {
                lineIndex = 10;
            }
        }

        if (lineIndex < dialegLines.Length)
        {
            StartCoroutine(ShowLine());

        }
    }

    private IEnumerator ShowLine()
    {
        dialogtext.text = string.Empty;

        foreach (char caracter in dialegLines[lineIndex])
        {
            dialogtext.text += caracter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void CollisionDoor(Collider2D collision)
    {
        //if (GameManagerController.instance.keys.Count == 0)
        //{
        //    isObjectDestroy = false;
        //}
        //else if (GameManagerController.instance.keys.Count > 0 && GameManagerController.instance.OpenDoorForKey(gameObject.GetComponent<DoorsController>().idDoor))
        //{
        //    isPlayerInrRange = false;
        //    isObjectDestroy = true;
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerInrRange)
        {
            isPlayerInrRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isPlayerInrRange)
        {
            isPlayerInrRange = false;
            StopAllCoroutines();
            ClosePanel();
        }
    }

}
