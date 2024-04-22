using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canBePressed;
    public KeyCode keyToBePressed;
    public GameObject justHitEffect, goodHitEffect, perfectHitEffect, missHitEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToBePressed))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                if (transform.position.y > 0.1f)
                {
                    GameManager.instance.JustHit();
                    Instantiate(justHitEffect, justHitEffect.transform.position, justHitEffect.transform.rotation);
                }
                else if (transform.position.y > 0.05f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodHitEffect, goodHitEffect.transform.position, goodHitEffect.transform.rotation);
                }
                else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectHitEffect, perfectHitEffect.transform.position, perfectHitEffect.transform.rotation);
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Button")
        {
            canBePressed = true;
            ++GameManager.instance.counter;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
                canBePressed = false;
                GameManager.instance.NoteMiss();
                //Instantiate(missHitEffect, missHitEffect.transform.position, missHitEffect.transform.rotation);
        }
    }
}
