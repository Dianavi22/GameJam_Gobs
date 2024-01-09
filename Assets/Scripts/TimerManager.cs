using UnityEngine;
using System.Collections;
using TMPro;

public class TimerManager : MonoBehaviour
{

    private static TimerManager _instance;

    public static TimerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instance of Null. TimerManager is NULL");
            }

            return _instance;
        }
    }
    
    [SerializeField] private TextMeshProUGUI TimerText;
    //[SerializeField] public int ServingTime;
    public static int ServingTime;
    private float ElapsedTime;
    [SerializeField] private float TimeLeft;
    public static float TimerLeftTime;
    
    /// <summary>
    ///  This can be second bonus win if player has served in time, otherwise
    ///  we will pass here number of secoonds of penality received
    /// </summary>
    public static float SecondOfPenalityOrBonus;

    public static bool IsPenalized;
    public static bool IsBonus;

    // Use this for initialization
    void Start()
    {
        ServingTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.Play)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                if (ServingTime > 0)
                {
                    ServingTime--;
                }
                UpdateTimer(TimeLeft);
            } else
            {
                Debug.LogWarning("Time is UP !");
                TimeLeft = 0;
                TimerLeftTime = TimeLeft;
                //GameManager.OnGameStateChanged += GameManagerOnTimeUp;
            }
        }
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        if (IsPenalized)
        {
            currentTime -= SecondOfPenalityOrBonus;
        }
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
