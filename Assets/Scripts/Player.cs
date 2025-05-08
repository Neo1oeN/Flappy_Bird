using System.Runtime.CompilerServices;
using Mono.Cecil;
using UnityEngine;

public class Player : MonoBehaviour
{   
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int SpriteIndex;
   private Vector3 direction;
   public float gravity= -9.8f;
   public float strenght= 5f;


    private void Awake()
    {
        // Debug.Log("I am awake");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Debug.Log("is am just waking up");
        // InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {

        Vector3 position;
        position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
   {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown((0))) 
        {

            direction = Vector3.up*strenght;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            {
                if( touch.phase == TouchPhase.Began) 
                {
                 direction = Vector3.up*strenght;

                }
            }
        }

        direction.y += gravity * Time.deltaTime;

        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        SpriteIndex++;
        if
        (
            SpriteIndex >= sprites.Length
        )
        {SpriteIndex = 0;}
        spriteRenderer.sprite = sprites[SpriteIndex];
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindFirstObjectByType<GameManager>().IncreaseScore();
        }
    }



}

