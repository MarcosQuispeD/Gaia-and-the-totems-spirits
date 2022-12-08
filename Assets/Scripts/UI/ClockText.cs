using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {  
        myText.text = Clock.instance.myText.text; 
    }
}
