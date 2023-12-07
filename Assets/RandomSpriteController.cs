using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteController : MonoBehaviour
{
    [SerializeField] private List<Sprite> possibleSprites;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // set a random sprite
        var randInt = Random.Range(0, possibleSprites.Count - 1);
        spriteRenderer.sprite = possibleSprites[randInt];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Sprite> GetPossibleSprites()
    {
        return possibleSprites;
    }
}
