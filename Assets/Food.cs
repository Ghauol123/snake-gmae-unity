using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private void Start()
    {
        RandomFood();
    }

    private void RandomFood()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Thay đổi vị trí ngẫu nhiên của food
        Vector3 randomPosition = new Vector3(x, y, 0.0f);
        transform.position = randomPosition;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            RandomFood();
        }
    }
}
