using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelContrroller : MonoBehaviour
{
    public float speed;
    public float changeTime = 3.0f;
    public bool horizontal;
    Rigidbody2D rigidbody2d;

    float timer;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (horizontal)
        {
            position.x = position.x + Time.deltaTime*speed * direction;
        }
        else
        {
            position.y = position.y + Time.deltaTime*speed * direction;
        }
        
        rigidbody2d.MovePosition(position);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        MouseController player = other.gameObject.GetComponent<MouseController>();
        if (player != null)
        {
            //if (Input.GetMouseButtonDown(0)) //тут неудачная попытка убить врага, кликая на левую кнопку мыши
            //{
                //Destroy(gameObject);
            //}
            player.ChangeHealth(-1);
            player.renderer.material.SetColor("_Color", Color.red); //если мышь попадает на ангела, то уменьшается ХП и она становится красной
        }

        
    }
}
