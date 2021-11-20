using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;

    public TextAsset backLayer;
    public TextAsset frontLayer;

    //probably replace this late?
    public Vector2 levelSize;
}
