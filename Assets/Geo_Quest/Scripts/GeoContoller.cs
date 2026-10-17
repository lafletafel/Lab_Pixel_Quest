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

    // Color switching
    public Color[] availableColors = new Color[] { Color.red, Color.green, Color.blue };
    private int currentColorIndex = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && availableColors != null && availableColors.Length > 0)
        {
            spriteRenderer.color = availableColors[currentColorIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);

        // Press Alpha1 to cycle through the three colors
        if (Input.GetKeyDown(KeyCode.Alpha1) && availableColors != null && availableColors.Length > 0)
        {
            CycleColor();
        }
    }

    private void CycleColor()
    {
        currentColorIndex = (currentColorIndex + 1) % availableColors.Length;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = availableColors[currentColorIndex];
        }
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
            case "ColorSwitch":
                {
                    // left intentionally empty - color switching is controlled by Alpha1 key
                    break;
                }
        }
    }
}