using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPos 
{
    public class ContainerPos : ScriptableObject
    {
        public List<Vector2> photoPos = new List<Vector2>();
    }
    public class ContainerSprite : ScriptableObject
    {
        public List<Sprite> sprites = new List<Sprite>();
    }
}
