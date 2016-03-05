using UnityEngine;

public class AddScoreOnClick : MonoBehaviour
{
    public int Score = 1;

    void OnMouseDown()
    {
        AchievementsController.instance.AddScore(Score);
    }
}
