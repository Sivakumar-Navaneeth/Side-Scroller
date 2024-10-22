using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] public float speed = 10;
    private float SpeedMult = 1; // 1000;
    [SerializeField] public float jumpforce = 1;
    public LayerMask ground;
    private bool isGround;
    public Transform feet;
    public float groundcircle;
    public LogicManagerScript logic;
    private bool PlayerisAlive = true;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerisAlive)
        {
            float HorizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(HorizontalInput * speed * SpeedMult , body.velocity.y);
            if (HorizontalInput > 0.01f)
                transform.localScale = 3 * Vector2.one;
            else if (HorizontalInput < -0.01f)
                transform.localScale = new Vector2(-3, 3);

            isGround = Physics2D.OverlapCircle(feet.position, groundcircle, ground);

            if (Input.GetKey(KeyCode.Space) && isGround)
                body.velocity = new Vector2(body.velocity.x, jumpforce * SpeedMult );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("GameOver - Fail");
            logic.GameOverFail();
            transform.localScale = new Vector2(3, -3);
            PlayerisAlive = false;
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("GameOver - Pass");
            logic.GameOverPass();
            // transform.localScale = new Vector2(3, -3);
            PlayerisAlive = false;
        }
    }
}
