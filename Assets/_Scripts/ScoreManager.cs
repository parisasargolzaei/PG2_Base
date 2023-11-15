using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour, IDataPersistance
{
    public static ScoreManager scoremanager;
    public TextMeshProUGUI scoreUI;
    int totalscore = 0;

    private void Awake() {
        if(scoremanager == null)
        {
            scoremanager = this;
        }
    }

    private void Start() 
    {
        scoreUI.text = "Score: " + totalscore.ToString();
    }

    public void UpdateScore(int score)
    {
        totalscore += score;
        // totalscore = totalscore + score;
        Debug.Log(totalscore);
        scoreUI.text = "Score: " + totalscore.ToString();
    }

    // Game data that we want to store and load
    public void SaveData(ref GameData data)
    {
        data.score = this.totalscore;
    }

    public void LoadData(GameData data)
    {
        this.totalscore = data.score;
    }
}
