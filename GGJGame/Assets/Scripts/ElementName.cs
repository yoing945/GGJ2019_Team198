using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素名
public class ElementName
{
    //[yl] Base Element Name
    public const string Man = "Man";                                    //男性
    public const string Woman = "Woman";                                //女性
    public const string Ill = "Ill";                                    //生病
    public const string Time = "Time";                                  //单位时间
    public const string Money = "Money";                                //单位金钱

    //[yl] Combine Element Name
    public const string IllMan = "IllMan";                              //生病男性
    public const string IllWoman = "IllWoman";                          //生病女性
    public const string Boy = "Boy";                                    //男孩
    public const string Girl = "Girl";                                  //女孩
    public const string OldMan = "OldMan";                              //老男人
    public const string OldWoman = "OldWoman";                          //老女人

    //[yl] Has Result Element Name
    public const string Sankouzhijia = "Sankouzhijia";                  //三口之家

}


//[yl] 简单起见使用单例
public class ElementNameMgr
{
    private static ElementNameMgr instatnce;

    //constructor
    private ElementNameMgr()
    {
        InitElementsCNDict();
        InitNetDict();
        InitResultElementDict();
        InitElementsNumLimitDict();
    }

    public static ElementNameMgr getInstance()
    {
        if (null == instatnce)
            instatnce = new ElementNameMgr();
        return instatnce;
    }

    private Dictionary<string, string> elementsCNDict;                  //中英文对照字典
    private Dictionary<string[][], string[]> netElementRelationDict;      //网状结构元素关系字典
    private List<string> elementsHasResult;                             //不参与合成的结果元素
    private Dictionary<string, int> elementsNumLimitDict;               //元素个数限制,超过个数限制的元素将不会加入组合


    private void InitElementsCNDict()
    {
        elementsCNDict = new Dictionary<string, string>();
        elementsCNDict.Add(ElementName.Man, "男性");
        elementsCNDict.Add(ElementName.Woman, "女性");
        elementsCNDict.Add(ElementName.Ill, "生病");
        elementsCNDict.Add(ElementName.Time, "单位时间");
        elementsCNDict.Add(ElementName.Money, "单位金钱");

        elementsCNDict.Add(ElementName.IllMan, "生病男性");
        elementsCNDict.Add(ElementName.IllWoman, "生病女性");
        elementsCNDict.Add(ElementName.Boy, "男孩");
        elementsCNDict.Add(ElementName.Girl, "女孩");
        elementsCNDict.Add(ElementName.OldMan, "老男人");
        elementsCNDict.Add(ElementName.OldWoman, "老女人");

        elementsCNDict.Add(ElementName.Sankouzhijia, "三口之家");

    }

    private void InitNetDict()
    {
        netElementRelationDict = new Dictionary<string[][], string[]>();
        //combine Boy or Girl
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Man, ElementName.Woman, ElementName.Time } },
            new string[] { ElementName.Boy, ElementName.Girl});
        //combine IllMan
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Man, ElementName.Ill } },
            new string[] { ElementName.IllMan });
        //combine IllWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Ill } },
            new string[] { ElementName.IllWoman });
        //combine OldMan
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Man, ElementName.Ill } },
            new string[] { ElementName.IllWoman });
        //combine OldWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Ill } },
            new string[] { ElementName.IllWoman });

        //combine Sankouzhijia
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Girl },
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Boy }},
            new string[] { ElementName.Sankouzhijia });
    }

    private void InitResultElementDict()
    {
        elementsHasResult = new List<string>();
        elementsHasResult.Add(ElementName.Sankouzhijia);
    }

    private void InitElementsNumLimitDict()
    {
        elementsNumLimitDict = new Dictionary<string, int>();
        elementsNumLimitDict.Add(ElementName.Time, 2);
        elementsNumLimitDict.Add(ElementName.Money, 2);
    }

    //[yl] 获取中文名
    public string getElementCNName(string enName)
    {
        if (elementsCNDict.ContainsKey(enName))
            return elementsCNDict[enName];
        Debug.LogError("[yl] No such key:" + enName + " In elementsCNDict");
        return "";
    }

    //[yl] 获取网状关系字典
    public Dictionary<string[][], string[]> getNetElementRelationDict()
    {
        return netElementRelationDict;
    }

    //[yl] 获取需要显示结果的元素列表
    public List<string> getElementsHasResult()
    {
        return elementsHasResult;
    }

    //[yl] 获取元素个数限制
    public int getElementNumLimitValue(string eName)
    {
        if (elementsNumLimitDict.ContainsKey(eName))
        {
            return elementsNumLimitDict[eName];
        }
        return 0;
    }

    //是否忽略个数限制
    public bool hasNumLimit(string[] inputElements)
    {
        int curNum = 0;
        foreach(var key in elementsNumLimitDict.Keys)
        {
            foreach(var element in inputElements)
            {
                if(element == key)
                {
                    curNum++;
                    if(curNum > elementsNumLimitDict[key])
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

}

public class SpriteResMgr
{
    private static SpriteResMgr instatnce;

    //constructor
    private SpriteResMgr()
    {
        Init();
    }

    public static SpriteResMgr getInstance()
    {
        if (null == instatnce)
            instatnce = new SpriteResMgr();
        return instatnce;
    }


    private string[] backGroundKeyWords = {"Ill", "Poor", "Rich"};
    private Sprite[] backGrounds;
    private Sprite[] chars;

    public void Init()
    {
        backGrounds = Resources.LoadAll<Sprite>("BackGround");
        chars = Resources.LoadAll<Sprite>("Character");
    }

    public Sprite[] getAllBGSprites()
    {
        return backGrounds;
    }

    public Sprite[] getCharsSprites()
    {
        return chars;
    }

    public string[] getBGKeyWords()
    {
        return backGroundKeyWords;
    }

    private Sprite getKeyWordBGSprite(string keyWord)
    {
        foreach(var s in backGrounds)
        {
            if (s.name.Contains(keyWord))
                return s;
        }
        Debug.LogError("[yl] no such keyword " + keyWord + " backGround");
        return null;
    }

    private Sprite[] getNormalBGSprites()
    {
        var sprites = new List<Sprite>();
        foreach(var s in backGrounds)
        {
            foreach(var keyword in backGroundKeyWords)
            {
                if (s != getKeyWordBGSprite(keyword))
                    sprites.Add(s);
            }
        }
        return sprites.ToArray();
    }

    public Sprite getBGSprite(string[] elements)
    {
        foreach (var keyword in backGroundKeyWords)
        {
            foreach (var elementName in elements)
            {
                if (elementName.Contains(keyword))
                {
                    return getKeyWordBGSprite(keyword);
                }
            }
        }
        var normalBGs = getNormalBGSprites();
        int index = Random.Range(0, normalBGs.Length);
        return normalBGs[index];
    }

    public Sprite[] getElementsSprites(string[] elements)
    {
        var finalSprites = new List<Sprite>();
        foreach(var e in elements)
        {
            var eSprites = new List<Sprite>();
            foreach(var s in chars)
            {
                if(s.name.Contains(e))
                {
                    eSprites.Add(s);
                }
            }
            if(eSprites.Count > 0)
            {
                int index = Random.Range(0, eSprites.Count);
                finalSprites.Add(eSprites[index]);
            }
        }
        return finalSprites.ToArray();
    }
}


