using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GamePhase { Preparation, Internship, Interview }
    public GamePhase currentPhase = GamePhase.Preparation;

    public int academicStatus = 0;  // �w�̓X�e�[�^�X
    public int communicationStatus = 0;  // �R�~���j�P�[�V�����\�̓X�e�[�^�X
    public int cooperationStatus = 0;  // �����X�e�[�^�X
    public int responsibilityStatus = 0;  // �ӔC���X�e�[�^�X
    public int proactivityStatus = 0;  // �ϋɐ��X�e�[�^�X
    public int jobHuntingExperienceStatus = 0;  // �A���o���X�e�[�^�X
    public int CoinStatus = 0;  // �A���o���X�e�[�^�X

    public int currentMonth = 4; // 4������J�n
    public int currentYear = 1;  // 1�N������J�n

    // UI Text�R���|�[�l���g�̎Q��
    public Text academicText;
    public Text communicationText;
    public Text cooperationText;
    public Text responsibilityText;
    public Text proactivityText;
    public Text jobHuntingExperienceText;
    public Text CoinText;
    public Text dateText; // �w�N�ƌ���\�����邽�߂̃e�L�X�g

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
        academicText.text = "�w�� : " + academicStatus.ToString();
        communicationText.text = "�R�~���� : " + communicationStatus.ToString();
        cooperationText.text = "������ : " + cooperationStatus.ToString();
        responsibilityText.text = "�ӔC�� : " + responsibilityStatus.ToString();
        proactivityText.text = "�ϋɐ� : " + proactivityStatus.ToString();
        jobHuntingExperienceText.text = "�A���o���l : " + jobHuntingExperienceStatus.ToString();
        CoinText.text = "���� : " + CoinStatus.ToString();
        UpdateDateDisplay();
    }

    void UpdateDateDisplay()
    {
        dateText.text = "��w" + currentYear.ToString() + "�N�� : " + currentMonth.ToString() + "��";
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
