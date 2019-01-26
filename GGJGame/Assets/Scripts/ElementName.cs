using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[yl] 元素名
public class ElementName
{
    //[yl] Base Element Name
    public const string Man = "Man";            //男人
    public const string Women = "Women";        //女人
    public const string Health = "Health";      //健康
    public const string Ill = "Ill";            //生病
    public const string Time = "Time";          //一个单位时间
    public const string Money = "Money";        //一个单位金钱

    //[yl] Combine Element Name
    public const string HealthMan = Health + Man;
    public const string HealthWomen = Health + Women;
    public const string IllMan = Ill + Man;
    public const string IllWomen = Ill + Women;
    public const string HealthBoy = HealthMan + Time;
    public const string HealthGirl = HealthWomen + Time;
    public const string HealthYoungMan = HealthBoy + Time;
    public const string HealthYoungWomen = HealthGirl + Time;


}


