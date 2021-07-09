using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

public class Example: MonoBehaviour
{
    private static Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    private static Candy previousSelected = null;
    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;

    public int Id;

    private Vector2[] adjacentDirections = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
    };

    public Vector3 objective;

    GameObject newCandy;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objective = Vector3.zero;
    }

    private void OnMouseDown()
    {
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
            if (previousSelected == null)
            {
                SelectCandy();
            }
            else
            {
                SwapSprite(previousSelected.gameObject);
                previousSelected.DeselectCandy();
                //SelectCandy();
            }
        }
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
        previousSelected = gameObject.GetComponent<Candy>();
    }

    private void DeselectCandy()
    {
        isSelected = false;
        spriteRenderer.color = Color.white;
        previousSelected = null;
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
}*/