using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SchemaCtrl 
{
    [MenuItem("Assets/CreateEditor/SchemaPos")]
    public static Res CreatePosSchema()
    {
        Res asset = ScriptableObject.CreateInstance<Res>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/PosSchema.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
  
}
