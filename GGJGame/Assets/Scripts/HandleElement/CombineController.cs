using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素组合控制器
public class CombineController
{

    //[yl] 组合,返回组合而成的元素名英文名
    public static string DoCombine(string[] elementNames)
    {
        var elementDict = ElementNameMgr.getInstance().elementsDict;
        foreach( var key in elementDict.Keys)
        {
            string elementFullNameJudge = CustomFunc.DeepCopy<string>(elementDict[key][1]);
            for(int i = 0; i < elementNames.Length; ++i)
            {
                var curEEnName = elementNames[i];
                if (!elementDict.ContainsKey(curEEnName))
                {
                    Debug.LogError("No such Key:" + curEEnName + " In elementDict");
                    return "";
                }

                var curEFullName = elementDict[curEEnName][1];
                //如果不包含元素全名,那么目标元素无法组合
                if(!elementFullNameJudge.Contains(curEFullName))
                {
                    break;
                }
                elementFullNameJudge = elementFullNameJudge.Replace(curEFullName, "");
                if(elementFullNameJudge == "")
                {
                    if(i == elementNames.Length - 1)
                    {
                        return key;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        return "";
    }

    public static string DoCombineByNetRelation(string[] inputElements)
    {
        var NERD = ElementNameMgr.getInstance().netElementRelationDict;
        foreach(var reasons in NERD.Keys)
        {
            var allInReasons = true;
            for(int i = 0; i < inputElements.Length; ++i)
            {
                var inReasons = false;
                //判断其中一个输入元素是否在因元素中
                for(int j = 0; j< reasons.Length; ++j)
                {
                    if (reasons[j] == inputElements[i])
                    {
                        inReasons = true;
                        break;
                    }
                }
                //有输入元素不在因元素中,那么排除这个这一种转换
                if (!inReasons)
                {
                    allInReasons = false;
                    break;
                }
                
            }
            if (allInReasons)
            {
                var value = NERD[reasons];
                int index = Random.Range(0, value.Length);
                return value[index];
            }
        }
        return "";
    }
}