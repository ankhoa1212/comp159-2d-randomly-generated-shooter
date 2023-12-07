using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSpriteController : MonoBehaviour
{
    [SerializeField] private List<Sprite> backwardsSprites;
    [SerializeField] private List<Sprite> leftSprites;
    [SerializeField] private List<Sprite> rightSprites;
    [SerializeField] private List<Sprite> forwardsSprites;

    [SerializeField] private float spriteTransitionDelay = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int index;
    private bool changingSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        changingSprite = false;
    }

    // for when player is disabled/enabled again during next level transition
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        changingSprite = false;
    }

    private void IncrementIndex(int length)
    {
        if (index + 1 == length)
        {
            index = 0;
        }
        index++;
    }

    private IEnumerator AdjustSprite(List<Sprite> sprites)
    {
        if (!changingSprite)
        {
            changingSprite = true;
            yield return new WaitForSeconds(spriteTransitionDelay);
            spriteRenderer.sprite = sprites[index];
            IncrementIndex(sprites.Count);
            changingSprite = false;
        }
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var movement = rb.velocity;
        if (movement == Vector2.zero)
        {
            return;
        }
        if (Math.Abs(movement.x) > Math.Abs(movement.y))
        {
            if (movement.x < 0)
            {
                StartCoroutine(AdjustSprite(leftSprites));
            }
            else
            {
                StartCoroutine(AdjustSprite(rightSprites));
            }
        }
        else
        {
            if (movement.y > 0)
            {
                StartCoroutine(AdjustSprite(forwardsSprites));
            }
            else
            {
                StartCoroutine(AdjustSprite(backwardsSprites));
            }
        }
    }
}
