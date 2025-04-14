using System;
using UnityEngine;

public class Apple : PickUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float additionSpeed=3f;
    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator=FindAnyObjectByType<LevelGenerator>();

    }
    protected override void onPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(additionSpeed);
    }
}
