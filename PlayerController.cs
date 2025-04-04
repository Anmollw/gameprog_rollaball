using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0 ;
     private int level = 1;
     private int collectiblesCount = 0;
     private int ccforlvlup = 4 ;
     public GameOverScript GameOverScreen ;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI LvlText;
    public GameObject Wintextobject;
    public GameObject loseTextObject;
    private Rigidbody rb;
    public int playerscore;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetcountText();
        Setlvltext();
        Wintextobject.SetActive(false);
        loseTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetcountText()
    {
        countText.text= "Score: " + playerscore.ToString() ;
        if(playerscore>=12)
        {
            Wintextobject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void Setlvltext()
    {
        LvlText.text = "Level: " + level.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX,0.0f , movementY);
        rb.AddForce(movement * speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            SetcountText();
            GameOverScreen.setup(playerscore);
            Destroy(gameObject);
            
        }
    }

    public void addscore(int scoretoadd)
    {
        playerscore+= scoretoadd;
    }

    public void LevelUp()
    {
        level= level + 1 ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            addscore(1);
            // addscore() is implement to update the score value based on different task completions or events
            SetcountText();
            collectiblesCount++ ;
            if (collectiblesCount >= ccforlvlup)
            {
                LevelUp();
                collectiblesCount = 0;
            }
            Setlvltext();
         }
    }
}
