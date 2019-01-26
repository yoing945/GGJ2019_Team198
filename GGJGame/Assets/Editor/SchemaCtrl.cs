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

    [MenuItem("Assets/CreateEditor/SchemaBasicMat")]
    public static ResMaterial CreateBasicMatSchema()
    {
        ResMaterial asset = ScriptableObject.CreateInstance<ResMaterial>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/BasicMatSchema.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
