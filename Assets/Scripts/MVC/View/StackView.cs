using System;
using UnityEngine;

public class StackView : MonoBehaviour
{
    [SerializeField] BlockView blockPrefab;

    [SerializeField] Transform buildingPoint1;
    [SerializeField] Transform buildingPoint2;
    [SerializeField] Transform buildingPoint3;
    
    [SerializeField] Transform buildingPoint4;
    [SerializeField] Transform buildingPoint5;
    [SerializeField] Transform buildingPoint6;

    int currentPoint;
    float currentHeight;

    float blockHeight => blockPrefab.transform.localScale.y;

    void Start ()
    {
        currentPoint = 0;
        currentHeight = -blockHeight;
    }

    public void AddBlock (BlockData block)
    {
        Transform parent = null;
        switch (currentPoint)
        {
            case 0:
                parent = buildingPoint1;
                currentHeight += blockHeight;
                break;
            case 1:
                parent = buildingPoint2;
                break;
            case 2:
                parent = buildingPoint3;
                break;
            case 3:
                parent = buildingPoint4;
                currentHeight += blockHeight;
                break;
            case 4:
                parent = buildingPoint5;
                break;
            case 5:
                parent = buildingPoint6;
                break;
        }
        BlockView instance = Instantiate(blockPrefab, parent);
        Vector3 position = instance.transform.position;
        position.y += currentHeight;
        instance.transform.position = position;

        currentPoint = (currentPoint + 1) % 6;
    }
}