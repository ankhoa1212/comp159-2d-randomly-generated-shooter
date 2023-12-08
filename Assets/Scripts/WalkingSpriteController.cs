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
        Initialize();
    }

    // for when player is disabled/enabled again during next level transition
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
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
            if (index < sprites.Count)
            {
                spriteRenderer.sprite = sprites[index];
            }
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

    // size of inputs should be divisible by 4
    public void SetAllSprites(List<Sprite> inputs)
    {
        var i = 0;
        var size = inputs.Count / 4;
        SetBackwardsSprites(AddSpriteInputs(inputs, i, size));
        i += size;
        SetLeftSprites(AddSpriteInputs(inputs, i, size));
        i += size;
        SetRightSprites(AddSpriteInputs(inputs, i, size));
        i += size;
        SetForwardsSprites(AddSpriteInputs(inputs, i, size));
        Initialize();
    }

    private static List<Sprite> AddSpriteInputs(List<Sprite> inputs, int index, int size)
    {
        List<Sprite> spriteInputs = new List<Sprite>();
        for (int x = index; x < index + size; x++)
        {
            spriteInputs.Add(inputs[x]);
        }

        return spriteInputs;
    }

    private void SetBackwardsSprites(List<Sprite> inputs)
    {
        backwardsSprites = inputs;
    }
    private void SetLeftSprites(List<Sprite> inputs)
    {
        leftSprites = inputs;
    }
    private void SetRightSprites(List<Sprite> inputs)
    {
        rightSprites = inputs;
    }
    private void SetForwardsSprites(List<Sprite> inputs)
    {
        forwardsSprites = inputs;
    }
}
