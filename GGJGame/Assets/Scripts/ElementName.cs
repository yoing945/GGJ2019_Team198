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
    public const string Poor = "Poor";

    public const string IllBoy = "IllBoy";
    public const string IllGirl = "IllGirl";
    public const string IllMan = "IllMan";                              //生病男性
    public const string IllWoman = "IllWoman";                          //生病女性
    public const string IllOldMan = "IllOldMan";
    public const string IllOldWoman = "IllOldWoman";

    public const string RichMan = "RichMan";
    public const string RichWoman = "RichWoman";
    public const string RichOldMan = "RichOldMan";
    public const string RichOldWoman = "RichOldWoman";

    public const string PoorBoy = "PoorBoy";
    public const string PoorGirl = "PoorGirl";
    public const string PoorMan = "PoorMan";
    public const string PoorWoman = "PoorWoman";
    public const string PoorOldMan = "PoorOldMan";
    public const string PoorOldWoman = "PoorOldWoman";

    public const string Boy = "Boy";                                    //男孩
    public const string Girl = "Girl";                                  //女孩
    public const string OldMan = "OldMan";                              //老男人
    public const string OldWoman = "OldWoman";                          //老女人

    //[yl] Has Result Element Name
    public const string Sankouzhijia = "Sankouzhijia";                  //三口之家
    public const string Gueryuan = "Gueryuan";
    public const string Danqinjiating = "Danqinjiating";
    public const string Gugualaoren = "Gugualaoren";
    public const string Tuhao = "Tuhao";
    public const string Wanglaowu = "Wanglaowu";
    public const string Liushou = "Liushou";
    public const string Hougong = "Hougong";
    public const string Fupo = "Fupo";
    public const string Sishitongtang = "Sishitongtang";
    public const string Qiongbi = "Qiongbi";
    public const string Yanglaoyuan = "Yanglaoyuan";
    public const string Yiyuan = "Yiyuan";
    public const string Dingke = "Dingke";
    public const string Gay = "Gay";
    public const string Les = "Les";
    public const string Danshen = "Danshen";
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

		elementsCNDict.Add(ElementName.Poor, "贫穷");
		
        elementsCNDict.Add(ElementName.Boy, "男孩");
        elementsCNDict.Add(ElementName.Girl, "女孩");
        elementsCNDict.Add(ElementName.OldMan, "老男人");
        elementsCNDict.Add(ElementName.OldWoman, "老女人");

        elementsCNDict.Add(ElementName.IllBoy, "生病男孩");
        elementsCNDict.Add(ElementName.IllGirl, "生病女孩");
        elementsCNDict.Add(ElementName.IllMan, "生病男性");
        elementsCNDict.Add(ElementName.IllWoman, "生病女性");
        elementsCNDict.Add(ElementName.IllOldMan, "生病老男人");
        elementsCNDict.Add(ElementName.IllOldWoman, "生病老女人");

        elementsCNDict.Add(ElementName.RichMan, "富男");
        elementsCNDict.Add(ElementName.RichWoman, "富女");
        elementsCNDict.Add(ElementName.RichOldMan, "富公");
        elementsCNDict.Add(ElementName.RichOldWoman, "富婆");

        elementsCNDict.Add(ElementName.PoorGirl, "贫穷女孩");
        elementsCNDict.Add(ElementName.PoorBoy, "贫穷男孩");
        elementsCNDict.Add(ElementName.PoorMan, "贫穷男人");
        elementsCNDict.Add(ElementName.PoorWoman, "贫穷女人");
        elementsCNDict.Add(ElementName.PoorOldMan, "贫穷老男人");
        elementsCNDict.Add(ElementName.PoorOldWoman, "贫穷老女人");

        elementsCNDict.Add(ElementName.Sankouzhijia, "三口之家");
		elementsCNDict.Add(ElementName.Gueryuan, "孤儿院");
        elementsCNDict.Add(ElementName.Danqinjiating, "单亲家庭");
        elementsCNDict.Add(ElementName.Gugualaoren, "孤寡老人的家");
        elementsCNDict.Add(ElementName.Tuhao, "土豪的家");
        elementsCNDict.Add(ElementName.Wanglaowu, "黄金王老五");
        elementsCNDict.Add(ElementName.Liushou, "留守的家");
        elementsCNDict.Add(ElementName.Hougong, "后宫");
        elementsCNDict.Add(ElementName.Fupo, "富婆的家");
        elementsCNDict.Add(ElementName.Sishitongtang, "四世同堂");
        elementsCNDict.Add(ElementName.Qiongbi, "穷逼的家");
        elementsCNDict.Add(ElementName.Yanglaoyuan, "养老院");
        elementsCNDict.Add(ElementName.Yiyuan, "医院全家福");
        elementsCNDict.Add(ElementName.Dingke, "丁克家庭");
        elementsCNDict.Add(ElementName.Gay, "基佬之家");
        elementsCNDict.Add(ElementName.Les, "百合之家");
        elementsCNDict.Add(ElementName.Danshen, "单身狗");

    }

    private void InitNetDict()
    {
        netElementRelationDict = new Dictionary<string[][], string[]>();

        //combine Poor
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Ill, ElementName.Man},
                new string[] { ElementName.Ill, ElementName.Woman},
                new string[] { ElementName.Ill, ElementName.OldMan},
                new string[] { ElementName.Ill, ElementName.OldWoman},
                new string[] { ElementName.Ill, ElementName.Boy},
                new string[] { ElementName.Ill, ElementName.Girl},
            },
            new string[] { ElementName.Boy, ElementName.Girl });

        //combine PoorBoy
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.Boy} },
            new string[] { ElementName.PoorBoy});
        //combine PoorGirl
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.Girl} },
            new string[] { ElementName.PoorGirl });
        //combine PoorMan
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.Man} },
            new string[] { ElementName.PoorMan });
        //combine PoorWoman
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.Woman} },
            new string[] { ElementName.PoorWoman });
        //combine PoorOldMan
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.OldMan} },
            new string[] { ElementName.PoorOldMan });
        //combine PoorOldWoman
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Poor, ElementName.OldWoman} },
            new string[] { ElementName.PoorOldWoman });

        //combine Boy or Girl
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Man, ElementName.Woman, ElementName.Time } },
            new string[] { ElementName.Boy, ElementName.Girl});

        //combine OldMan
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Man, ElementName.Time, ElementName.Time } },
            new string[] { ElementName.OldMan });
        //combine OldWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Time, ElementName.Time } },
            new string[] { ElementName.OldWoman });


        //combine IllBoy
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Boy, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllBoy });
        //combine IllGirl
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Boy, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllGirl });
        //combine IllMan
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.Man, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllMan });
        //combine IllWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllWoman });
        //combine IllOldMan
        netElementRelationDict.Add(
            new string[][] {
                new string[] { ElementName.OldMan, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllOldMan });
        //combine IllOldWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.OldWoman, ElementName.Ill, ElementName.Money } },
            new string[] { ElementName.IllOldWoman });

        //combine RichMan
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Man, ElementName.Money } },
            new string[] { ElementName.RichMan });
        //combine RichWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Money } },
            new string[] { ElementName.RichWoman });
        //combine RichOldMan
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.OldMan, ElementName.Money } },
            new string[] { ElementName.RichOldMan });
        //combine RichOldWoman
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.OldWoman, ElementName.Money } },
            new string[] { ElementName.RichOldWoman });
        

        //combine Sankouzhijia
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Girl },
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Boy }},
            new string[] { ElementName.Sankouzhijia });

        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.OldMan, ElementName.OldWoman,ElementName.OldWoman }
            ,   new string[]{ ElementName.OldMan, ElementName.OldMan, ElementName.OldWoman },
             new string[]{ ElementName.OldMan, ElementName.OldMan, ElementName.OldMan },
            new string[]{ ElementName.OldWoman, ElementName.OldWoman,ElementName.OldWoman }},
            new string[] { ElementName.Yanglaoyuan });

        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Boy, ElementName.Girl,ElementName.Girl }
            ,   new string[]{ ElementName.Boy, ElementName.Boy, ElementName.Girl },
             new string[]{ ElementName.Boy, ElementName.Boy, ElementName.Boy },
            new string[]{ ElementName.Girl, ElementName.Girl, ElementName.Girl }},
            new string[] { ElementName.Gueryuan });

        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.OldMan, ElementName.OldWoman,ElementName.Girl, ElementName.Boy, ElementName.Man, ElementName.Woman }
            ,   new string[]{ ElementName.OldMan, ElementName.OldWoman,ElementName.Girl, ElementName.Man, ElementName.Woman },
             new string[]{ ElementName.OldMan, ElementName.OldWoman, ElementName.Boy, ElementName.Man, ElementName.Woman } ,
            new string[]{ ElementName.OldMan, ElementName.Girl, ElementName.Boy, ElementName.Man, ElementName.Woman },
            new string[]{  ElementName.OldWoman,ElementName.Girl, ElementName.Boy, ElementName.Man, ElementName.Woman },
            new string[]{ ElementName.OldMan, ElementName.Boy, ElementName.Man, ElementName.Woman },
            new string[]{ ElementName.OldWoman, ElementName.Boy, ElementName.Man, ElementName.Woman }},
            new string[] { ElementName.Sishitongtang });

        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.RichOldMan, ElementName.RichOldWoman, ElementName.RichMan, ElementName.RichWoman },
            new string[]{ ElementName.RichOldMan, ElementName.RichOldWoman},
            new string[] { ElementName.RichMan, ElementName.RichWoman } },
            new string[] { ElementName.Tuhao });

		netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Woman },
                new string[]{ ElementName.Woman, ElementName.Man, ElementName.Woman, ElementName.Woman }},
            new string[] { ElementName.Hougong });

        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.Woman},
                new string[]{ ElementName.Man}
            },
            new string[] { ElementName.Hougong });


        //combine Qiongbi
        netElementRelationDict.Add(
            new string[][]{
                new string[]{ ElementName.PoorBoy, ElementName.PoorMan, ElementName.PoorWoman },
                new string[]{ ElementName.PoorBoy, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldMan },
                new string[]{ ElementName.PoorBoy, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldWoman },
                new string[]{ ElementName.PoorBoy, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldWoman, ElementName.PoorOldMan },
                new string[]{ ElementName.PoorGirl, ElementName.PoorMan, ElementName.PoorWoman },
                new string[]{ ElementName.PoorGirl, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldMan },
                new string[]{ ElementName.PoorGirl, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldWoman },
                new string[]{ ElementName.PoorGirl, ElementName.PoorMan, ElementName.PoorWoman, ElementName.PoorOldWoman, ElementName.PoorOldMan },},
             new string[] { ElementName.Qiongbi });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.OldMan, ElementName.Boy, ElementName.Girl, ElementName.OldWoman },
                new string[]{ ElementName.OldMan, ElementName.Boy, ElementName.Girl },
                new string[]{  ElementName.Boy, ElementName.Girl, ElementName.OldWoman },
                new string[]{ ElementName.OldMan,  ElementName.Girl, ElementName.OldWoman },
                new string[]{ ElementName.OldMan, ElementName.Boy, ElementName.OldWoman }},
           new string[] { ElementName.Liushou });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.Man, ElementName.Boy, ElementName.Girl},
            new string[]{ ElementName.Woman, ElementName.Boy, ElementName.Girl },
            new string[]{ ElementName.Man, ElementName.Boy},
            new string[]{ ElementName.Woman, ElementName.Girl },
            new string[]{ ElementName.Woman, ElementName.Boy},
            new string[]{ ElementName.Man, ElementName.Girl },
           },
           new string[] { ElementName.Danqinjiating });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.RichWoman, ElementName.Man, ElementName.Man},
            new string[]{ ElementName.RichWoman, ElementName.Man},
            new string[]{ ElementName.RichWoman, ElementName.Man, ElementName.Man,ElementName.Man},
            new string[]{ ElementName.RichWoman, ElementName.Man, ElementName.Man,ElementName.Man},
           },
           new string[] { ElementName.Fupo });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.RichWoman},
            new string[]{ ElementName.RichWoman},
           },
           new string[] { ElementName.Wanglaowu });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.Woman,ElementName.Man},
                new string[]{ ElementName.RichWoman,ElementName.Man},
                new string[]{ ElementName.Woman,ElementName.RichMan},
           },
           new string[] { ElementName.Dingke });

        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.Woman,ElementName.Woman},
                
           },
           new string[] { ElementName.Les });
        netElementRelationDict.Add(
           new string[][]{
                new string[]{ ElementName.Man, ElementName.Man},
           },
           new string[] { ElementName.Gay });

    }

    private void InitResultElementDict()
    {
        elementsHasResult = new List<string>();
        elementsHasResult.Add(ElementName.Sankouzhijia);
        elementsHasResult.Add(ElementName.Gueryuan);
        elementsHasResult.Add(ElementName.Danqinjiating);
        elementsHasResult.Add(ElementName.Gugualaoren);
        elementsHasResult.Add(ElementName.Tuhao);
        elementsHasResult.Add(ElementName.Wanglaowu);
        elementsHasResult.Add(ElementName.Liushou);
        elementsHasResult.Add(ElementName.Hougong);
        elementsHasResult.Add(ElementName.Fupo);
        elementsHasResult.Add(ElementName.Sishitongtang);
        elementsHasResult.Add(ElementName.Qiongbi);
        elementsHasResult.Add(ElementName.Yanglaoyuan);
        elementsHasResult.Add(ElementName.Yiyuan);
        elementsHasResult.Add(ElementName.Dingke);
        elementsHasResult.Add(ElementName.Gay);
        elementsHasResult.Add(ElementName.Les);
    }

    private void InitElementsNumLimitDict()
    {
        elementsNumLimitDict = new Dictionary<string, int>();
        elementsNumLimitDict.Add(ElementName.Time, 2);
        elementsNumLimitDict.Add(ElementName.Money, 2);
        elementsNumLimitDict.Add(ElementName.OldMan, 3);
        elementsNumLimitDict.Add(ElementName.OldWoman, 3);
        elementsNumLimitDict.Add(ElementName.Man, 3);
        elementsNumLimitDict.Add(ElementName.Girl, 3);
        elementsNumLimitDict.Add(ElementName.Boy, 3);
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
                    //[yl] Super Hard Code!!
                    if (e == "Man" || e == "Woman")
                    {
                        if(!s.name.Contains("Old"))
                        {
                            eSprites.Add(s);
                        }
                    }
                    else
                    {
                        eSprites.Add(s);
                    }
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


