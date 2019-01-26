using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素名
public class ElementName
{
    //[yl] Base Element Name
    public const string Man = "Man";                                    //男性
    public const string Women = "Women";                                //女性
    public const string Health = "Health";                              //健康
    public const string Ill = "Ill";                                    //生病
    public const string Time = "Time";                                  //单位时间
    public const string Money = "Money";                                //单位金钱

    //[yl] Combine Element Name
    public const string IllMan = Ill + Man;                             //生病男性
    public const string IllWomen = Ill + Women;                         //生病女性
    public const string Boy = Man + Women;                              //男孩
    public const string Girl = Man + Women;                             //女孩

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
    }

    public static ElementNameMgr getInstance()
    {
        if (null == instatnce)
            instatnce = new ElementNameMgr();
        return instatnce;
    }

    public Dictionary<string, string[]> elementsDict;
    public Dictionary<string[], string[]> netElementRelationDict;   //网状结构元素关系字典

    public void Init()
    {
        elementsDict = new Dictionary<string, string[]>();
        elementsDict.Add("Man", new string[] { "男性", ElementName.Man });
        elementsDict.Add("Women", new string[] { "女性", ElementName.Women });
        elementsDict.Add("Health", new string[] { "健康", ElementName.Health });
        elementsDict.Add("Ill", new string[] { "生病", ElementName.Ill });
        elementsDict.Add("Time", new string[] { "单位时间", ElementName.Time });
        elementsDict.Add("Money", new string[] { "单位金钱", ElementName.Money });
        elementsDict.Add("IllMan", new string[] { "生病男性", ElementName.IllMan });
        elementsDict.Add("IllWomen", new string[] { "生病女性", ElementName.IllWomen });
        elementsDict.Add("Boy", new string[] { "男孩", ElementName.Boy });
        elementsDict.Add("Girl", new string[] { "女孩", ElementName.Girl });

    }

    //[yl] 网状结构
    public void NetDictInit()
    {
        netElementRelationDict = new Dictionary<string[], string[]>();
        
    }
}


