using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnakeBase : MonoBehaviour
{
    protected Vector2 direction;

    protected abstract void Move();
    protected abstract void increaseTail();

    protected void ChangeDirection(Vector2 newDirection)
    {
        if (newDirection != -direction) // Hạn chế rẽ ngược lại
        {
            direction = newDirection;
        }
    }
}
