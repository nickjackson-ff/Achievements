using UnityEngine;

public class ViewAchievementsOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        // Open Game Center achievements view
		Prime31.GameCenterBinding.showAchievements();
    }
}
