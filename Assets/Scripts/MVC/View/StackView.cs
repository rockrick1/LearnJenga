﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StackView : MonoBehaviour
{
    public event Action<BlockData> OnBlockClick;

    
    [SerializeField] BlockView blockPrefab;

    [SerializeField] Transform buildingPoint1;
    [SerializeField] Transform buildingPoint2;
    [SerializeField] Transform buildingPoint3;
    
    [SerializeField] Transform buildingPoint4;
    [SerializeField] Transform buildingPoint5;
    [SerializeField] Transform buildingPoint6;

    [SerializeField] Transform focalPoint;
    [SerializeField] TextMeshPro gradeText;

    public Transform FocalPoint => focalPoint;

    readonly List<BlockView> blocks = new();
    int currentPoint;
    float currentHeight;

    float blockHeight => blockPrefab.Scale;

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
                UpdateFocalPoint();
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
                UpdateFocalPoint();
                break;
            case 4:
                parent = buildingPoint5;
                break;
            case 5:
                parent = buildingPoint6;
                break;
        }
        BlockView instance = Instantiate(blockPrefab, parent);
        instance.Setup(block);
        Vector3 position = instance.transform.position;
        position.y += currentHeight;
        instance.transform.position = position;
        instance.OnClick += HandleBlockClick;
        blocks.Add(instance);

        currentPoint = (currentPoint + 1) % 6;
    }

    void HandleBlockClick (BlockData data)
    {
        OnBlockClick?.Invoke(data);
    }

    public void SetGradeText (string text) => gradeText.text = text;

    void UpdateFocalPoint ()
    {
        Vector3 pos = focalPoint.transform.position;
        pos.y += blockHeight / 2;
        focalPoint.transform.position = pos;
    }

    public void RemoveGlasses ()
    {
        foreach (BlockView block in blocks)
        {
            block.SetPhysicsActive(true);
            if (block.Mastery == Mastery.Glass)
            {
                block.Destroy();
            }
        }
    }
}