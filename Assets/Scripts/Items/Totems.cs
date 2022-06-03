using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Totems : MonoBehaviour
{
    public static Totems instance;
    public TypeTotems Type;
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
        instance = this;
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
    }

    public void ActivatePanel()
    {
        isPlayerInrRange = true;
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
        StartCoroutine(TotemsDesactivate());
    }

    IEnumerator TotemsDesactivate()
    {
        yield return new WaitForSeconds(0.95f);
        dialogStart = false;
        dialogtext.text = string.Empty;
        dialogPanel.SetActive(false);
        isPlayerInrRange = false;
    }

    private IEnumerator ShowLine()
    {
        dialogtext.text = string.Empty;

        foreach (char caracter in dialegLines[lineIndex])
        {
            dialogtext.text += caracter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        ClosePanel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
}
