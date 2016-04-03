using UnityEngine;

public class ReportAchievementOnClick : MonoBehaviour
{
    public string Identifier;

	void Awake()
	{
		Prime31.GameCenterManager.reportAchievementFailedEvent += reportAchievementFailed;
		Prime31.GameCenterManager.reportAchievementFinishedEvent += reportAchievementFinished;
	}

    void OnMouseDown()
    {
		// Report progress percentage toward achievement
		if (Prime31.GameCenterBinding.isPlayerAuthenticated()) 
		{
			Prime31.GameCenterBinding.reportAchievement (Identifier, 100.0f);
		}

		else
		{
			Debug.Log ("Player was not authenticated shuga");
		}
	
	}


	void reportAchievementFinished( string identifier )
	{
		Debug.Log( "reportAchievementFinishedEvent: " + identifier );
	}

		
	void reportAchievementFailed( string error )
	{
		Debug.Log( "reportAchievementFailedEvent: " + error );
	}
}
