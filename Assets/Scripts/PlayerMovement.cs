using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton class: PlayerMovement
    public static PlayerMovement Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [Header("Initial Player: ")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [Header("Ball Collider: ")]
    [SerializeField] CircleCollider2D redBallCollider;
    [SerializeField] CircleCollider2D blueBallCollider;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }

        // stop rotation when key is released
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.angularVelocity = 0f;
        }
    }

    private void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

    private void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    private void Restart()
    {
        redBallCollider.enabled = false;
        blueBallCollider.enabled = false;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        //back to start position
    }
}
