using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct WorldLimits {
    public float superiorL, inferiorL, leftL, rightL;
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private WorldLimits worldLimits;

    [SerializeField]
    private TextMeshProUGUI textScore;

    [SerializeField]
    private int lifes = 3;

    [SerializeField]
    private GameObject panelDeath;

    [SerializeField]
    private Slider sliderLife;

    private int score = 0;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(instance);
        }
    }
    // Start is called before the first frame update
    void Start()
    { 
        UpdateScoreText();
        sliderLife.maxValue = lifes;
        sliderLife.value = lifes;  
    } 

    public void ScoreUp(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        textScore.text = "Score: " + score;
    }

    public bool PlayerDie() {
        lifes--;
        sliderLife.value = lifes;

        if(lifes <= 0) {
            panelDeath.SetActive(true);
            return true;
        }

        Debug.Log("lifes " + lifes);
        return false;
    }

    public void Replay() {
        score = 0;
        UpdateScoreText();
        lifes = 3;
        sliderLife.value = lifes;

        panelDeath.SetActive(false);
    }

    public WorldLimits GetWorldLimits() {return worldLimits;}

}
