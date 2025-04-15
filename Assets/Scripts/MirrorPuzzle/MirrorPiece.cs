using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MirrorPiece : MonoBehaviour
{
    [HideInInspector]
    public GameObject goalColl;
    private Vector3 offset;
    [HideInInspector]
    public bool isDragging = false;
    [HideInInspector]
    public bool isCompleted = false;
    
    
    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        offset = transform.position - mousePos;
        isDragging = true;
    }
    
    private void OnMouseDrag()
    {
        if (isDragging && !isCompleted)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos + offset;
        }
    }
    
    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void Reset()
    {
        isCompleted = false;
        GetComponent<Collider2D>().enabled = true;
        float r = Random.Range(-4f, 4f);
        r = r < 0 ? r-4f : r+4f;
        transform.localPosition = r * Vector3.right + Random.Range(-4f, 4f) * Vector3.up;
        Debug.Log(gameObject.name + " " + transform.position);
    }
    
}
