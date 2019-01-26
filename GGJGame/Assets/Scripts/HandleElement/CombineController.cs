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
}
