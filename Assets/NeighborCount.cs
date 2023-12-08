using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NeighborCount : MonoBehaviour
{
    private LevelController level;
    public TextMeshProUGUI neighborCount;
    
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        neighborCount.text = level.GetNeighborNum().ToString();
    }
    
    
    
}
