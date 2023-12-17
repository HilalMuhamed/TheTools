using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour
{
    public Score score;
    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        InvokeRepeating("IncreaseValue", 1f, 1f);
    }

    private void IncreaseValue()
    {
        score.addScore(1);
    }
}