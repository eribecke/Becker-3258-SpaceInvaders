using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float speed;
    private Vector3 direction = Vector2.right;
   
    void Awake()
    {
        for(int row = 0; row< rows; row++)
        {
            float width = 2.0f * (this.rows - 1);
            float height = 2.0f*(this.columns - 1);
            Vector2 centering = new Vector2(-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 1.0f), 0.0f);
            for(int col = 0; col < columns; col++)
            {
                Enemy enemy = Instantiate(this.enemies[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 0.8f;
                enemy.transform.localPosition = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;

        Vector3 left = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 right = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach(Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }
            if(direction == Vector3.right && enemy.position.x > (right.x-0.5f))
            {
                moveDown();
            }
            else if(direction == Vector3.left && enemy.position.x < (left.x+0.5f))
            {
                moveDown();
            }
        }

    }

    private void moveDown()
    {
        direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }


}
