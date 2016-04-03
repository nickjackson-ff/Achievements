using UnityEngine;

public class AchievementsController : MonoBehaviour
{
    public ClickyButton Logo;
    public TextMesh ScoreTextMesh;
    public int Score;
    public string LeaderboardID;

    public static AchievementsController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        LoadGame();

        // Authenticate player on Game Center ASAP
		Prime31.GameCenterBinding.authenticateLocalPlayer();
		Prime31.GameCenterBinding.showCompletionBannerForAchievements ();
		Prime31.GameCenterManager.reportScoreFailedEvent += reportScoreFailed;
		Prime31.GameCenterManager.reportScoreFinishedEvent += reportScoreFinished;
    }

    public int AddScore (int value)
    {
        Score += value;
        UpdateScore();
        
        // Report our total score for leaderboard
		Prime31.GameCenterBinding.reportScore(Score, "Gold");

        return Score;
    }

    public void LoadGame()
    {
        Score = PlayerPrefs.GetInt("TotalGold", 0);
        UpdateScore();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("TotalGold", Score);
        PlayerPrefs.Save();
    }

    public void UpdateScore()
    {
        ScoreTextMesh.text = Score + " gold";
    }

	void reportScoreFinished(string message)
	{
		Debug.Log( "resetAchievementsFinishedEvent: " + message );
	}


	void reportScoreFailed( string error )
	{
		Debug.Log( "resetAchievementsFailedEvent: " + error );
	}
}
