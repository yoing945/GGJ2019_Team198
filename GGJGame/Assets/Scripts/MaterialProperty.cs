using UnityEngine;

public class MaterialProperty : MonoBehaviour
{
    public string Name;
    public bool IsLeft;
    public string Label;

    public void SetProperty(string name, bool place, string label)
    {
        Name = name;
        IsLeft = place;
        Label = label;
    }
}