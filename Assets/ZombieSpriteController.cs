using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieSpriteController : MonoBehaviour
{
    [SerializeField] private List<Sprite> zombieSprites;
    [SerializeField] private int spritesPerType = 16;
    private SpriteRenderer spriteRenderer;
    private WalkingSpriteController walkingSpriteController;
    private bool zombieSpritesInitialized;
    // Start is called before the first frame update
    void Start()
    {
        // zombieSpritesInitialized = false;
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // walkingSpriteController = GetComponent<WalkingSpriteController>();
    }

    private void OnEnable()
    {
        zombieSpritesInitialized = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkingSpriteController = GetComponent<WalkingSpriteController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!zombieSpritesInitialized && spriteRenderer.sprite.name.Contains("_0"))
        {
            zombieSpritesInitialized = true;
            InitializeZombieSprites();
        }
    }

    public void InitializeZombieSprites()
    {
        var sprite = spriteRenderer.sprite;
        for (var index = 0; index < zombieSprites.Count; index++)
        {
            if (zombieSprites[index] == sprite)
            {
                var zombieIndex = index / spritesPerType; // set index of zombie type
                var newSprites = new List<Sprite>();
                for (var i = zombieIndex * spritesPerType; i < spritesPerType + zombieIndex * spritesPerType; i++) // add all zombie sprites to list
                {
                    newSprites.Add(zombieSprites[i]);
                }
                walkingSpriteController.SetAllSprites(newSprites);
                break;
            }
        }
        Debug.Log("test complete");
    }
}
