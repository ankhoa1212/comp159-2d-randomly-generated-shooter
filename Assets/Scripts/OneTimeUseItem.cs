using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeUseItem : MonoBehaviour
{
    [SerializeField] private UseItemType useItemType;
    public enum UseItemType
    {
        Barricade,
        Landmine
    }
    [SerializeField] private GameObject useItemPrefab;
    [SerializeField] private Transform useItemPoint;
    [SerializeField] private Sprite useItemImage; //
    [SerializeField] private GameObject pickupItem; // pickup item prefab that adds more uses of the item
    private int numItemUses;
    

    // Start is called before the first frame update
    void Start()
    {
        numItemUses = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool UseItem()
    {
        if (numItemUses > 0)
        {
            switch (useItemType)
            {
                case UseItemType.Barricade:
                    var placedGameObject = Instantiate(useItemPrefab, useItemPoint.position, useItemPoint.rotation);
                    numItemUses--;
                    Destroy(placedGameObject, 5);
                    break;
                case UseItemType.Landmine:
                    Instantiate(useItemPrefab, useItemPoint.position, useItemPoint.rotation);
                    numItemUses--;
                    break;
            }
            return true;
        }
        return false;
    }
    
    public Sprite GetUseItemImage()
    {
        return useItemImage;
    }

    public int GetNumberOfUses()
    {
        return numItemUses;
    }
}
