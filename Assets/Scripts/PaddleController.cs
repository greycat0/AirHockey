using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public enum Keyboard
    {
        WASD,
        Arrows
    }
    public struct CurrentKeyboard
    {
        public KeyCode left;
        public KeyCode right;
        public KeyCode forward;
        public KeyCode down;
    }
    public float Speed;
    public float Padding = 0.11f;
    public Keyboard MainKeyboard;
    private CurrentKeyboard currentKeyboard;
    private Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (MainKeyboard == Keyboard.WASD)
        {
            currentKeyboard.left = KeyCode.A;
            currentKeyboard.right = KeyCode.D;
            currentKeyboard.forward = KeyCode.W;
            currentKeyboard.down = KeyCode.S;
        }
        else if (MainKeyboard == Keyboard.Arrows)
        {
            currentKeyboard.left = KeyCode.LeftArrow;
            currentKeyboard.right = KeyCode.RightArrow;
            currentKeyboard.forward = KeyCode.UpArrow;
            currentKeyboard.down = KeyCode.DownArrow;
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(currentKeyboard.left))
        {
            direction += Vector3.left;
        }
        else if (Input.GetKey(currentKeyboard.right))
        {
            direction += Vector3.right;
        }

        if (Input.GetKey(currentKeyboard.forward))
        {
            direction += Vector3.forward;
        }
        else if (Input.GetKey(currentKeyboard.down))
        {
            direction += Vector3.back;
        }
        body.velocity = direction * Speed * Time.deltaTime;
    }
}
