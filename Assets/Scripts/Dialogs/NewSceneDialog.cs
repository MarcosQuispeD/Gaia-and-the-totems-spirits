using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewSceneDialog : MonoBehaviour
{
    bool isPlayerInrRange;
    bool continueDialog = false;
    bool dialogStart;
    bool isObjectDestroy;
    int lineIndex;
    [SerializeField, TextArea(4, 6)] private string[] dialegLines;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogtext;

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
    private IEnumerator ShowLine()
    {
        dialogtext.text = string.Empty;

        foreach (char caracter in dialegLines[lineIndex])
        {
            dialogtext.text += caracter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider") && !isPlayerInrRange && !ManagerScene.instance.check)
        {
            isPlayerInrRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider") && isPlayerInrRange)
        {
            isPlayerInrRange = false;
            StopAllCoroutines();
            ClosePanel();
        }
    }
}
