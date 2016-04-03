using UnityEngine;
using System.Collections;

public class ResetAchievementsOnClcik : MonoBehaviour 
{
	public TextMesh ButtonLabel;

	private MeshRenderer myMeshRenderer;
	private Color originalBackgroundColor;
	private string originalButtonLabelText;

	private bool isDimmed;

	void Awake()
	{
		myMeshRenderer = GetComponent<MeshRenderer>();
		originalBackgroundColor = myMeshRenderer.material.color;
		originalButtonLabelText = ButtonLabel.text;
		Prime31.GameCenterManager.resetAchievementsFailedEvent += resetAchievementsFailed;
		Prime31.GameCenterManager.resetAchievementsFinishedEvent += resetAchievementsFinished;
	}

	void OnMouseDown()
	{
		if (isDimmed) return;
		Prime31.GameCenterBinding.resetAchievements();

		//AchievementsController.instance.SaveGame();

		SetResetButtonLabelText();
		//Invoke("SetOriginalButtonLabelText", 2f);
	}

	void SetResetButtonLabelText()
	{
		isDimmed = true;
		myMeshRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 0.75f);
		ButtonLabel.text = "...";
	}

	void SetOriginalButtonLabelText()
	{
		isDimmed = false;
		myMeshRenderer.material.color = originalBackgroundColor;
		ButtonLabel.text = originalButtonLabelText;
	}

	void resetAchievementsFinished()
	{
		Debug.Log( "resetAchievementsFinishedEvent" );
		SetOriginalButtonLabelText();

	}


	void resetAchievementsFailed( string error )
	{
		Debug.Log( "resetAchievementsFailedEvent: " + error );
		SetOriginalButtonLabelText();
	}

}
