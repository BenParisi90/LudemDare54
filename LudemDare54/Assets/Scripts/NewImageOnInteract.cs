using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewImageOnInteract : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite newSprite;

    [SerializeField]
    GameEvent gameEvent;

    Sprite originalSprite;

    Interactable interactable;

    void Awake()
    {
        
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
        originalSprite = spriteRenderer.sprite;
    }

    void Start()
    {
        GameState.instance.ResetGameAction += ResetGame;
    }

    void ResetGame()
    {
        spriteRenderer.sprite = originalSprite;
    }

    void Interact()
    {
        if(!GameState.instance.GameEvents[(int)gameEvent])
        {
            return;
        }
        spriteRenderer.sprite = newSprite;
    }
}
