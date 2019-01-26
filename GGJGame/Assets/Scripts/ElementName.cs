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
    }

    public static ElementNameMgr getInstance()
    {
        if (null == instatnce)
            instatnce = new ElementNameMgr();
        return instatnce;
    }

    private Dictionary<string, string> elementsCNDict;                  //中英文对照字典
    private Dictionary<string[], string[]> netElementRelationDict;      //网状结构元素关系字典
    private List<string> elementsHasResult;                             //中英文对照字典

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

        elementsCNDict.Add(ElementName.Sankouzhijia, "三口之家");

    }

    private void InitNetDict()
    {
        netElementRelationDict = new Dictionary<string[], string[]>();
        //combine Boy or Girl
        netElementRelationDict.Add(
            new string[] { ElementName.Man, ElementName.Woman, ElementName.Time },
            new string[] { ElementName.Boy, ElementName.Girl});
        //combine IllMan
        netElementRelationDict.Add(
            new string[] { ElementName.Man, ElementName.Ill },
            new string[] { ElementName.IllMan });
        //combine IllWoman
        netElementRelationDict.Add(
            new string[] { ElementName.Woman, ElementName.Ill },
            new string[] { ElementName.IllWoman });
        //combine Sankouzhijia [girl]
        netElementRelationDict.Add(
            new string[] { ElementName.Woman, ElementName.Man, ElementName.Girl },
            new string[] { ElementName.Sankouzhijia });
        //combine Sankouzhijia [boy]
        netElementRelationDict.Add(
            new string[] { ElementName.Woman, ElementName.Man, ElementName.Boy },
            new string[] { ElementName.Sankouzhijia });

    }

    private void InitResultElementDict()
    {
        elementsHasResult = new List<string>();
        elementsHasResult.Add(ElementName.Sankouzhijia);
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
    public Dictionary<string[], string[]> getNetElementRelationDict()
    {
        return netElementRelationDict;
    }

    public List<string> getElementsHasResult()
    {
        return elementsHasResult;
    }

}


