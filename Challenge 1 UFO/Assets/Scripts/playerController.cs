using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

       



      

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Pickup"))
        {

            other.gameObject.SetActive(false);
            count++;
            if (count == 12)
            {
                transform.position = new Vector2(70.0f, 0f);
            }
            SetCountText();

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            if (count < 20)
            {
                if (lives > 0)
                    lives--;
            }
            SetLivesText();
        }
        
    }

   
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win!" + " Created by Christopher Alfian";
        }
        
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            gameObject.SetActive(false);
            winText.text = "You Lose!" + " Created by Christopher Alfian";
        }

    }

}




