﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素组合控制器
public class CombineController
{
    //根据元素间的网状关系输出
    public static string DoCombineByNetRelation(string[] inputElements)
    {
        var NERD = ElementNameMgr.getInstance().getNetElementRelationDict();
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