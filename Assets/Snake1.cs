using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake1 : SnakeBase
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 0.2f;
    public List<Transform> tail;
    public Transform SnakeTail;
    private void Start()
    {
        tail = new List<Transform>();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        tail.Add(this.transform);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput < 0 && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (horizontalInput > 0 && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
        else if (verticalInput > 0 && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (verticalInput < 0 && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
    }
    protected override void Move()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x + direction.x * speed,
            transform.position.y + direction.y * speed,
            transform.position.z);

        transform.position = newPosition;
    }
    protected override void increaseTail()
    {
        for(int i = tail.Count -1; i>0;i--){
            tail[i].position = tail[i-1].position;
        }
    }
    private void FixedUpdate()
    {
        increaseTail();
        Move();
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.SnakeTail);
        segment.position = tail[tail.Count - 1].position;
        tail.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food"){
            Grow();
        }
    }
}