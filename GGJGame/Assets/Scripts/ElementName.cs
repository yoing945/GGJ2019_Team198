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
    public const string Time = "Time";                                  //一个单位时间
    public const string Money = "Money";                                //一个单位金钱

    //[yl] Combine Element Name
    public const string HealthMan = Health + Man;                       //健康男性
    public const string HealthWomen = Health + Women;                   //健康女性
    public const string IllMan = Ill + Man;                             //生病男性
    public const string IllWomen = Ill + Women;                         //生病女性
    public const string HealthBoy = HealthMan + Time;                   //健康男孩
    public const string HealthGirl = HealthWomen + Time;                //健康女孩
    public const string HealthYoungMan = HealthBoy + Time;              //健康男青年
    public const string HealthYoungWomen = HealthGirl + Time;           //健康女青年


}


