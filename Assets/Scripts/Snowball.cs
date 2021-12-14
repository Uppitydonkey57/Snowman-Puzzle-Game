using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Snowball : Moveable
{

    public int sizes;

    [SerializeField] private float maxSize;

    private Vector3 initialSize;

    [HideInInspector] public int increases = 0;

    [SerializeField] private LayerMask tileLayer;

    [SerializeField] private LayerMask goalLayer;

    [SerializeField] private LayerMask snowballLayer;

    [SerializeField] private GameObject covering;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();

        initialSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push(Vector2 direction)
    {
        Tile currentTile = IsBlocked(Vector2.zero, tileLayer).GetComponent<Tile>();
        WarmTile currentWarmTile = IsBlocked(Vector2.zero, tileLayer).GetComponent<WarmTile>();

        GameObject snowballTileObject = IsBlocked(direction, snowballLayer);
        Snowball snowballTile = null;

        if (snowballTileObject != null)
        {
            snowballTile = snowballTileObject.GetComponent<Snowball>();
        }

        Collider2D currentGoal = Physics2D.OverlapPoint(transform.position + (Vector3)direction, goalLayer);

        if (currentGoal != null)
        {
            currentGoal.GetComponent<Goal>().WinCheck(this);
        }

        if (currentTile != null && !currentTile.isTurned)
        {
            if (increases < sizes)
            {
                ChangeSize(1);
            } else
            {
                covering.SetActive(true);
            }

            currentTile.Turn();
        }

        if (currentWarmTile != null && !currentWarmTile.isTurned)
        {
            if (increases > 0)
            {
                ChangeSize(-1);
            }
        }

        if (snowballTile != null)
        {
            //snowballTile.ChangeSize(sizes);
            //Destroy(gameObject);
        }

        Move(direction);
    }

    void ChangeSize(int amount)
    {
        Vector3 scale = transform.localScale;

        float sizeIncrease = ((maxSize - initialSize.x) / sizes) * Mathf.Sign(amount);

        transform.DOScale(new Vector3(scale.x + sizeIncrease, scale.y + sizeIncrease, 0), gm.TurnSpeed);

        increases += amount;
    }
}
