using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScrollerRef;
    private float goodNoteScore = 100;
    private float perfectNoteScore = 200;
    private float hitNoteScore = 50;
    public float currentScore = 0;
    public Text scoreText;
    private float totalNotes;
    public static GameManager instance;
    public float counter = 0;
    public GameObject endGamePanel;
    public Text FinalscoreText;
    void Start()
    {
        instance= this;
        scoreText.text = "Score : 0";
        totalNotes = FindObjectsOfType<NoteController>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            startPlaying= true;
            beatScrollerRef.hasStarted= true;
            music.Play();
        }
        if (counter == totalNotes)
        {
            Time.timeScale = 0;
            music.Pause();
            endGamePanel.SetActive(true);
            FinalscoreText.text = "Score : " + currentScore;

        }

    }

    public void NoteHit()
    {
        scoreText.text =  "Score : " + currentScore;
        
    }

    public void PerfectHit()
    {
        currentScore+= perfectNoteScore;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore+= goodNoteScore;
        NoteHit();
    }

    public void JustHit()
    {
        currentScore+= hitNoteScore;
        NoteHit();
    }


    public void NoteMiss()
    {
        Debug.Log(currentScore);
        scoreText.text = "Score : " + currentScore;
    }
}
