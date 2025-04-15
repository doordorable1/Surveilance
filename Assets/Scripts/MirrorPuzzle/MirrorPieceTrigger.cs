using System;
using UnityEngine;

public class MirrorPieceTrigger : MonoBehaviour
{
    private MirrorPiece mirrorPiece;


    private void Start()
    {
        mirrorPiece = GetComponentInParent<MirrorPiece>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == mirrorPiece.goalColl && !mirrorPiece.isCompleted)
        {
            mirrorPiece.isCompleted = true;
            mirrorPiece.isDragging = false;
            mirrorPiece.transform.position = mirrorPiece.goalColl.transform.position;
            mirrorPiece.GetComponent<Collider2D>().enabled = false;
            MirrorPuzzleManager.Instance.PieceCountUp();
            //GetComponent<SpriteRenderer>().sortingOrder = 0;
            //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
