using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CustomFunc
{
    public static T DeepCopy<T>(T obj)
    {
        object retval;
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            //序列化成流
            bf.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            //反序列化成对象
            retval = bf.Deserialize(ms);
            ms.Close();
        }
        return (T)retval;
    }

}
