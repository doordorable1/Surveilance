using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MirrorPuzzleManager : MonoBehaviour
{
    public static MirrorPuzzleManager Instance;
    public GameObject pieces;
    public GameObject goalColls;
    public int pieceCount = 0;
    public GameObject clearImage;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Init();
        clearImage.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPuzzle();
        }
    }

    private void Init()
    {
        int i = 0;
        Collider2D[] colls = goalColls.GetComponentsInChildren<Collider2D>();
        foreach (var piece in pieces.GetComponentsInChildren<MirrorPiece>())
        {
            piece.goalColl = colls[i].gameObject;
            i++;
        }
    }

    public void ResetPuzzle()
    {
        pieceCount = 0;
        clearImage.SetActive(false);
        foreach (var piece in pieces.GetComponentsInChildren<MirrorPiece>())
        {
            piece.Reset();
        }
    }
    
    public void PieceCountUp()
    {
        pieceCount++;
        if (pieceCount == 3)
        {
            ClearPuzzle();
        }
    }

    public void ClearPuzzle()
    {
        clearImage.SetActive(true);
        MonsterManager.Instance.SetCommon(4);
        CutChangeManager.Instance.PlayCutCoroutine();
    }
    

}
