using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private float tileSize;
    public float TileSize { get { return tileSize; } }

    [SerializeField] private float turnSpeed;
    public float TurnSpeed { get { return turnSpeed; } }

    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnWin()
    {
        Debug.Log("You Won");
    }
}
