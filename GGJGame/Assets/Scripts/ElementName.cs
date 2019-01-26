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

    //[yl] Has Result Element Name

}


//[yl] 简单起见使用单例
public class ElementNameMgr
{
    private static ElementNameMgr instatnce;

    //constructor
    private ElementNameMgr()
    {
        Init();
        NetDictInit();

    }

    public static ElementNameMgr getInstance()
    {
        if (null == instatnce)
            instatnce = new ElementNameMgr();
        return instatnce;
    }

    private Dictionary<string, string> elementsCNDict;                  //中英文对照字典
    private Dictionary<string[], string[]> netElementRelationDict;      //网状结构元素关系字典

    public void Init()
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

    }

    //[yl] 网状结构
    public void NetDictInit()
    {
        netElementRelationDict = new Dictionary<string[], string[]>();
        netElementRelationDict.Add(
            new string[] { ElementName.Man, ElementName.Woman, ElementName.Time },
            new string[] { ElementName.Boy, ElementName.Girl});
        netElementRelationDict.Add(
            new string[] { ElementName.Man, ElementName.Ill },
            new string[] { ElementName.IllMan });
        netElementRelationDict.Add(
            new string[] { ElementName.Woman, ElementName.Ill },
            new string[] { ElementName.IllWoman });
    }

    public string getElementCNName(string enName)
    {
        if (elementsCNDict.ContainsKey(enName))
            return elementsCNDict[enName];
        Debug.LogError("[yl] No such key:" + enName + " In elementsCNDict");
        return "";
    }

    public Dictionary<string[], string[]> getNetElementRelationDict()
    {
        return netElementRelationDict;
    }
}


