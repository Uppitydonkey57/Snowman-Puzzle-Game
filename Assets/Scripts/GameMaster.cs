using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private float tileSize;
    public float TileSize { get { return tileSize; } }

    [SerializeField] private float turnSpeed;
    public float TurnSpeed { get { return turnSpeed; } }

    [SerializeField] private GameObject winMenu;

    private bool hasWon;

    [SerializeField] private LevelData[] levels;

    LevelBuilder builder;
    private int currentLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        builder = GetComponent<LevelBuilder>();

        builder.BuildLevel(levels[currentLevel]);
        currentLevel++;
    }

    private void OnEnable()
    {
        Goal.OnWin += OnWin;
    }

    private void OnDisable()
    {
        Goal.OnWin -= OnWin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            builder.DestroyLevel();
            builder.BuildLevel(levels[currentLevel - 1]);
        }

        if (Input.anyKeyDown && hasWon)
        {
            builder.DestroyLevel();
            builder.BuildLevel(levels[currentLevel]);
            currentLevel++;
            winMenu.SetActive(false);
            hasWon = false;
        }
    }

    void OnWin()
    {
        Debug.Log("You Won");
        winMenu.SetActive(true);
        hasWon = true;
    }
}
