using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Snowball : Moveable
{

    public int sizes;

    [SerializeField] private float maxSize;

    private Vector3 initialSize;

    public int increases = 0;

    [SerializeField] private LayerMask tileLayer;

    [SerializeField] private LayerMask goalLayer;

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
        Tile currentTile = Physics2D.OverlapPoint(transform.position, tileLayer).GetComponent<Tile>();

        Collider2D currentGoal = Physics2D.OverlapPoint(transform.position, goalLayer);

        if (currentGoal != null)
        {
            currentGoal.GetComponent<Goal>().WinCheck(this);
        }

        if (currentTile != null && !currentTile.isTurned)
        {
            if (increases < sizes)
            {
                Vector3 scale = transform.localScale;

                float sizeIncrease = (maxSize - initialSize.x) / sizes;

                transform.DOScale(new Vector3(scale.x + sizeIncrease, scale.y + sizeIncrease, 0), gm.TurnSpeed);

                increases++;
            }

            currentTile.Turn();
        }

        Move(direction);
    }
}
