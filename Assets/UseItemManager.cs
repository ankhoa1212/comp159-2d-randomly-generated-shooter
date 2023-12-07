using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItemManager : MonoBehaviour
{
    private int currentItemIndex;
    [SerializeField] private List<GameObject> playerItems; // player's current items
    [SerializeField] private Image itemBoxImage;
    private OneTimeUseItem currentItem;
    private DisplayController display;
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial item index
        currentItemIndex = 0;
        currentItem = playerItems[currentItemIndex].GetComponent<OneTimeUseItem>();
        // Display the initial item counts
        display = GetComponent<DisplayController>();
        display.SetText($"{currentItem.GetNumberOfUses()}");
    }

    // Update is called once per frame
    void Update()
    {
        // switch item based on number buttons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchItem(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem.UseItem())
            {
                display.SetText($"{currentItem.GetNumberOfUses()}");
            }
        }
    }

    private void SwitchItem(int index)
    {
        if (currentItemIndex != index)
        {
            currentItemIndex = index;
            currentItem = playerItems[currentItemIndex].GetComponent<OneTimeUseItem>();
            itemBoxImage.sprite = currentItem.GetUseItemImage(); // set item image sprite
            display.SetText($"{currentItem.GetNumberOfUses()}"); // display number of uses
        }
    }
}
