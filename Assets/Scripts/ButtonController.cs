using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public KeyCode keyCode;
    public Sprite defaultImage;
    public Sprite pressedSprite;
    public Light PointLight;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            spriteRenderer.sprite = pressedSprite;
            PointLight.gameObject.SetActive(true);
        }
        if(Input.GetKeyUp(keyCode))
        {
            spriteRenderer.sprite = defaultImage;
            PointLight.gameObject.SetActive(false);
        }
        
    }
}
