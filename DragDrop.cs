using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;
    private Vector2 startPosition;
    private GameObject card;
    private GameObject startParent;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if(isOverDropZone)
        {
            if(isAffordable())
            {
                transform.SetParent(dropZone.transform, false);
                subtractEnergy();
            } else {
                Debug.Log("Not enough energy");
                resetCardPosition();
            }
        }
        else
        {
            resetCardPosition();
        }
    }

    public void resetCardPosition()
    {
        transform.position = startPosition;
        transform.SetParent(startParent.transform, false);
    }

    private void subtractEnergy()
    {
        int cardCost = gameObject.GetComponent<Attributes>().COST;
        int energy = Int32.Parse(GameObject.Find("EnergyText").GetComponent<Text>().text);
        GameObject.Find("EnergyText").GetComponent<Text>().text = (energy - cardCost).ToString();
    }

    private bool isAffordable()
    {
        return gameObject.GetComponent<Attributes>().COST <= Int32.Parse(GameObject.Find("EnergyText").GetComponent<Text>().text);
    }
}
