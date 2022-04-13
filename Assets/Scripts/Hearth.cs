using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    [SerializeField] Sprite hearthFull;
    [SerializeField] Sprite hearthLow;

    [SerializeField] SpriteRenderer _spriteRenderer;
    void Awake()
    {
        ChangeSprite(true);
    }
    public void ChangeSprite(bool status) // false - low / true - full
    {
        if(status == true){
            _spriteRenderer.sprite = hearthFull;
        }else
        {
            _spriteRenderer.sprite = hearthLow;
        }
    }
}
