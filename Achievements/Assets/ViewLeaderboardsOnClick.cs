using UnityEngine;

public class ViewLeaderboardsOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        // Open Game Center leaderboards view
		Prime31.GameCenterBinding.showLeaderboardWithTimeScopeAndLeaderboard(GameCenterLeaderboardTimeScope.AllTime, "Gold");
    }
}
