using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberEffect : MonoBehaviour
{
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateSprite(int id)
    {
        SpriteRender _sprite = transform.GetComponent<SpriteRender>();
        if (_sprite == null) return;
        //id 0:点 1：1   2：8   3：9
        switch (id)
        {
            case 0:
                _sprite.sprite = sprites[0];
                break;
            case 1:
                _sprite.sprite = sprites[1];
                break;
            case 2:
                _sprite.sprite = sprites[2];
                break;
            default:
                _sprite.sprite = sprites[3];
                break;
        }
    }
}
