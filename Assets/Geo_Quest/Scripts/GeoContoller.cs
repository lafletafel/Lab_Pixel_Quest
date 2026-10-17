using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoContoller : MonoBehaviour
{
    public string nextLevel = ("Scene_2");
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public int speed = 5;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Debug.Log(Var2 + "World");
        //Var2 = "Goodbye";
        //Debug.Log(Var2 + "World");
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "boing":
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 9);
                    break;
                }
        }
    }
}