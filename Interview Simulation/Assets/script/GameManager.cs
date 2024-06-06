using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GamePhase { Preparation, Internship, Interview }
    public GamePhase currentPhase = GamePhase.Preparation;

    public int academicStatus = 0;  // 学力ステータス
    public int communicationStatus = 0;  // コミュニケーション能力ステータス
    public int cooperationStatus = 0;  // 協働ステータス
    public int responsibilityStatus = 0;  // 責任感ステータス
    public int proactivityStatus = 0;  // 積極性ステータス
    public int jobHuntingExperienceStatus = 0;  // 就活経験ステータス
    public int CoinStatus = 0;  // 就活経験ステータス

    public int currentMonth = 4; // 4月から開始
    public int currentYear = 1;  // 1年生から開始

    // UI Textコンポーネントの参照
    public Text academicText;
    public Text communicationText;
    public Text cooperationText;
    public Text responsibilityText;
    public Text proactivityText;
    public Text jobHuntingExperienceText;
    public Text CoinText;
    public Text dateText; // 学年と月を表示するためのテキスト

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateStatusDisplay();
    }

    public void UpdateActivity(string activityType)
    {
        switch (activityType)
        {
            case "Study":
                academicStatus += UnityEngine.Random.Range(10, 51);
                break;
            case "Club":
                CoinStatus -= UnityEngine.Random.Range(1000, 10000);
                communicationStatus += UnityEngine.Random.Range(5, 26);
                cooperationStatus += UnityEngine.Random.Range(5, 26);
                break;
            case "PartTimeJob":
                cooperationStatus += UnityEngine.Random.Range(0, 21);
                responsibilityStatus += UnityEngine.Random.Range(10, 41);
                CoinStatus += UnityEngine.Random.Range(1000, 3000);
                break;
            case "Play":
                communicationStatus += UnityEngine.Random.Range(5, 26);
                proactivityStatus += UnityEngine.Random.Range(5, 26);
                break;
        }
        AdvanceMonth();
        UpdateStatusDisplay();
    }

    public void AdvanceMonth()
    {
        currentMonth++;
        if (currentMonth > 12)
        {
            currentMonth = 1;
            currentYear++;
        }
        if (currentYear > 3)
        {
            currentPhase = GamePhase.Interview;
        }
        UpdateDateDisplay();
    }

    public void UpdateStatusDisplay()
    {
        academicText.text = "学力 : " + academicStatus.ToString();
        communicationText.text = "コミュ力 : " + communicationStatus.ToString();
        cooperationText.text = "協働力 : " + cooperationStatus.ToString();
        responsibilityText.text = "責任感 : " + responsibilityStatus.ToString();
        proactivityText.text = "積極性 : " + proactivityStatus.ToString();
        jobHuntingExperienceText.text = "就活経験値 : " + jobHuntingExperienceStatus.ToString();
        CoinText.text = "お金 : " + CoinStatus.ToString();
        UpdateDateDisplay();
    }

    void UpdateDateDisplay()
    {
        dateText.text = "大学" + currentYear.ToString() + "年生 : " + currentMonth.ToString() + "月";
    }

    public void MoveToInternshipScene()
    {
        SceneManager.LoadScene("Internship");
        
    }

    public void StartInternship()
    {
        currentPhase = GamePhase.Internship;
    }

    public void StartInterview()
    {
        currentPhase = GamePhase.Interview;
    }
}
