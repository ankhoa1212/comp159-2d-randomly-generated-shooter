using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;

    public void SetText(string displayText)
    {
        textObject.text = displayText;
    }
}
