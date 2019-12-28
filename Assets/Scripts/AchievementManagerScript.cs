using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchievementManagerScript : MonoBehaviour
{

    public Text possibleAchievements;
    public Text completedAchievements;

    string possibleAchievementsString;
    string completedAchievementsString;
    // Start is called before the first frame update
    void Start()
    {

        possibleAchievementsString = "Possible Achievements:\n";

        if (PlayerPrefs.GetInt("LevelOneTime") == 0){
            possibleAchievementsString += "Complete Level One in Under 180 Seconds.\n";
        }
        if (PlayerPrefs.GetInt("LevelTwoTime") == 0){
            possibleAchievementsString += "Complete Level Two in Under 200 Seconds.\n";
        }
        if (PlayerPrefs.GetInt("LevelThreeTime") == 0){
            possibleAchievementsString += "Complete Level Three in Under 240 Seconds.\n";
        }

        completedAchievementsString = "Completed Achievements:\n";

        if (PlayerPrefs.GetInt("LevelOneTime") == 1){
            completedAchievementsString += "Completed Level One in Under 180 Seconds.\n";
        }
        if (PlayerPrefs.GetInt("LevelTwoTime") == 1){
            completedAchievementsString += "Completed Level Two in Under 200 Seconds.\n";
        }
        if (PlayerPrefs.GetInt("LevelThreeTime") == 1){
            completedAchievementsString += "Completed Level Three in Under 240 Seconds.\n";
        }



        possibleAchievements.text = possibleAchievementsString;
        completedAchievements.text = completedAchievementsString;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainScreenButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
