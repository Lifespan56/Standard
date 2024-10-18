using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public partial class RocketDashboard : MonoBehaviour
{
    [SerializeField] private Text nowScoreTxt;
    [SerializeField] private Text thisTimeTopScoreTxt;
    [SerializeField] private Text highScoreTxt;
    [SerializeField] private GameObject bottomChackPivot;
    [SerializeField] private GameObject worldCanvas;

    private float currentScore;
    private float highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("higtScore");
        highScoreTxt.text = "TopHigh : " + highScore.ToString("N1") + " M";
    }

    public void UpdateStatUIPosition()
    {
        worldCanvas.transform.position = bottomChackPivot.transform.position;

        if (bottomChackPivot.transform.position.y > currentScore)
        {
            currentScore = bottomChackPivot.transform.position.y;
            thisTimeTopScoreTxt.text = "This Time Top : " + currentScore.ToString("N1") + " M";
        }

        nowScoreTxt.text = "Now : " + bottomChackPivot.transform.position.y.ToString("N1") + " M";
    }

    public void recording()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetFloat("higtScore", currentScore);
        }
    }

}


