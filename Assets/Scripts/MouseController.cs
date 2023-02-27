using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float speed = 5.0f;
    public string inputID; //переменная для определения какого игрока надо перемещать (1 - для первого игрока,2 - для второго игрока.Указывается в инспекторе)

    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    int currentHealth;


    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public SpriteRenderer renderer;

    Rigidbody2D rigidbody2d;
    float vertical;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"+inputID);
        vertical = Input.GetAxis("Vertical"+inputID);
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("MoveX",lookDirection.x);
        animator.SetFloat("MoveY", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NPC character = hit.collider.GetComponent<NPC>();
                if (character != null)
                {
                    character.DisplayDialog();
                }

            }
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        //position.x = position.x + speed * horizontal*Time.deltaTime;
        //position.y = position.y + speed * vertical*Time.deltaTime;
        transform.Translate(Vector3.right * speed * horizontal * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vertical * Time.deltaTime);
        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //renderer.material.SetColor("_Color",Color.red);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
