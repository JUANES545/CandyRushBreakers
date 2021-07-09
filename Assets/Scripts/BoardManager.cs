using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BoardManager : MonoBehaviour
{
    public static BoardManager sharedInstance;
    public List<GameObject> prefabs = new List<GameObject>();
    public GameObject currentCandy;
    public int xSize, ySize;
    public float marginX, marginY;

    private GameObject[,] candies;
    int idx = -1;

    public bool isShifting { get; set; }

    private Candy selectedCandy;

    void Start()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        Vector2 offset = new Vector2(currentCandy.GetComponent<SpriteRenderer>().bounds.size.x + marginX, 
            currentCandy.GetComponent<SpriteRenderer>().bounds.size.y + marginY);
        CreateInitialBoard(offset);

        /*Vector2 offset = new Vector2(currentCandy.GetComponent<BoxCollider2D>().size.x + marginX,
            currentCandy.GetComponent<BoxCollider2D>().size.y + marginY);
        CreateInitialBoard(offset);*/

        /*Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        CreateInitialBoard(offset);*/
    }

    private void CreateInitialBoard(Vector2 offset)
    {
        candies = new GameObject[xSize, ySize];
        float startX = this.transform.position.x;
        float starty = this.transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y <  ySize; y++)
            {
                GameObject newCandy = Instantiate(currentCandy, new Vector3(startX + (offset.x * x),
                    (starty + (offset.y * y)), 0), currentCandy.transform.rotation);
                newCandy.name = $"Candy[{x}][{y}]";

                do
                {
                    idx = UnityEngine.Random.Range(0, prefabs.Count);
                } while ((x > 0 && idx == candies[x-1, y].GetComponent<Candy>().Id) ||
                         (y > 0 && idx == candies[x,y -1].GetComponent<Candy>().Id));
                
                GameObject candy = prefabs[idx];
                newCandy.GetComponent<Candy>().Id = idx;
                Instantiate(candy, newCandy.transform.position, newCandy.transform.rotation);
                
                candies[x, y] = newCandy;
            }
        }
    }
    
    void Update()
    {
        
    }
}
