using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class LevelBuilder : MonoBehaviour
{
    public LevelData currentLevel;

    public GameObject[] objects;

    GameMaster gm;

    private GameObject currentLevelObject;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildLevel(LevelData data) 
    {
        gm = FindObjectOfType<GameMaster>();

        currentLevelObject = new GameObject(data.name);

        BuildLayer(data.backLayer, 2, data.levelSize).transform.SetParent(currentLevelObject.transform);
        BuildLayer(data.frontLayer, 0, data.levelSize).transform.SetParent(currentLevelObject.transform);
    }

    public void DestroyLevel()
    {
        Destroy(currentLevelObject);
    }

    public GameObject BuildLayer(TextAsset layer, float zPos, Vector2 size)
    {
        Vector2 pos = Vector2.zero;

        string[] levelList = layer.text.Split(',','\n');

        Transform layerObject = new GameObject(layer.name).transform;
            
        for (int i = 0; i < levelList.Length - 1; i++)
        {
            int currentSpot = int.Parse(levelList[i]);

            if (currentSpot > -1)
            {
                GameObject currentObject = Instantiate(objects[currentSpot], new Vector3(pos.x * gm.TileSize, pos.y * gm.TileSize, zPos), Quaternion.identity);

                if (levelList[i] == "3")
                {
                    Tile tile = currentObject.GetComponent<Tile>();
                    tile.Turn();
                }

                currentObject.transform.SetParent(layerObject);
            }

            pos.x++;

            if (pos.x > size.x - 1)
            {
                pos.x = 0;
                pos.y--;
            }
        }

        return layerObject.gameObject;
    }
}

[ExecuteInEditMode]
[CustomEditor(typeof(LevelBuilder))]
public class LevelBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelBuilder builder = (LevelBuilder)target;

        if (GUILayout.Button("Build Level")) 
        {
            builder.BuildLevel(builder.currentLevel);
        }
    }
}