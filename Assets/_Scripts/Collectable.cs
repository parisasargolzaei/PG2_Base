using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.scoremanager.UpdateScore(score);
            Debug.Log("Collided!");
            Destroy(gameObject);
        }
    }
}
