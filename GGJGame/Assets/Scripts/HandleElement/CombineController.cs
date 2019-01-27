using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素组合控制器
public class CombineController
{

    //根据元素间的网状关系输出
    public static string DoCombineByNetRelation(string[] inputElements)
    {
        var elementNameMgr = ElementNameMgr.getInstance();
        var NERD = elementNameMgr.getNetElementRelationDict();

        foreach(var allreasons in NERD.Keys)
        {
            foreach (var reasons in allreasons)
            {
                //若元素没有个数限制,那么reasons和inputElements必须完全对应
                if (!elementNameMgr.hasNumLimit(inputElements))
                {
                    if (inputElements.Length != reasons.Length)
                        continue;
                }
                var tempReasons = new List<string>(reasons);
                for (int i = 0; i < inputElements.Length; ++i)
                {
                    //判断其中一个输入元素是否在因元素中
                    for (int j = 0; j < tempReasons.Count; ++j)
                    {
                        if (tempReasons[j] == inputElements[i])
                        {
                            tempReasons.RemoveAt(j);
                            break;
                        }
                    }

                }
                if (tempReasons.Count == 0)
                {
                    var value = NERD[allreasons];
                    int index = Random.Range(0, value.Length);
                    return value[index];
                }
            }

        }
        return "";
    }

    //[yl] 元素是否在结果列表
    public static bool isInResultList(string eName)
    {
        if (ElementNameMgr.getInstance().getElementsHasResult().Contains(eName))
        {
            return true;
        }
        return false;
    }

    //[yl] 获取结果图片列表
    public static List<Sprite> getResultSprites(string[] elements)
    {
        var spritesMgr = SpriteResMgr.getInstance();
        var bgKeyWords = spritesMgr.getBGKeyWords();
        var sprites = new List<Sprite>();
        sprites.Add(spritesMgr.getBGSprite(elements));
        sprites.AddRange(spritesMgr.getElementsSprites(elements));

        return sprites;
    }
}