using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private float scores = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    public Text scoreText;
    public DeathMenu deathmenu;


    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        if (scores >= scoreToNextLevel)
            LevelUp();

        scores += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)scores).ToString();
    }
    void LevelUp() {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

       GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }
    public void OnDeath()
    {
        isDead = true;
        deathmenu.ToggleEndMenu(scores);
    }
}
