using UnityEngine;
using System.Collections;
using TMPro;

public class TimerManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] public int ServingTime;
    private float ElapsedTime;
    private float TimeLeft;
    

    public static float TimerLeftTime;

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
            } else
            {
                Debug.Log("Time is UP !");
                TimeLeft = 0;
                TimerLeftTime = TimeLeft;
                //GameManager.OnGameStateChanged += GameManagerOnTimeUp;
            }
            ElapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(ElapsedTime / 60);
            int secondes = Mathf.FloorToInt(ElapsedTime % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
        }
    }

}
