using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private static Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    private static Candy PreviousSelected = null;
    public SpriteRenderer spriteRenderer;
    private bool isSelected = false;

    public int Id;

    private Vector2[] adjacentDirections = new[]
    {
        Vector2.up,
        Vector2.down, 
        Vector2.left,
        Vector2.right
    };
    
    public Vector3 objective;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objective = Vector3.zero;
    }
    void Start()
    {

    }

    private void Update()
    {
        if (objective != Vector3.zero)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, objective, 5 * Time.deltaTime);
        }
    }

    private void SelectCandy()
    {
        isSelected = true;
        spriteRenderer.color = selectedColor;
        PreviousSelected = gameObject.GetComponent<Candy>();
    }

    private void DeselectCandy()
    {
        isSelected = false;
        spriteRenderer.color = Color.red;
        PreviousSelected = null;
    }

    public void OnMouseDown()
    {
        Debug.Log("Perrito");
        if (spriteRenderer.sprite == null || BoardManager.sharedInstance.isShifting)
        {
            return;
        }

        if (isSelected)
        {
            DeselectCandy();
        }
        else
        {
            if (PreviousSelected == null)
            {
                SelectCandy();
            }
            else
            {
                SwapSprite(PreviousSelected.gameObject);
                PreviousSelected.DeselectCandy();
                SelectCandy();
            }
        }

    }
    
    public void SwapSprite(GameObject candy)
    {
        if (spriteRenderer.sprite == candy.GetComponent<SpriteRenderer>().sprite)
        {
            return;
        }

        this.objective = candy.transform.position;
        candy.GetComponent<Candy>().objective = this.transform.position;
    }
}
