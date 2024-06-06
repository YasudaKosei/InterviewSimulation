using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

// インターンシップの質問を表すクラス
[Serializable]
public class InternshipQuestion
{
    public string question; // 質問文
    public List<InternshipAnswer> answers; // 回答のリスト
}

// インターンシップの回答を表すクラス
[Serializable]
public class InternshipAnswer
{
    public string answerText; // 回答文
    public int experiencePoints; // 経験値
}

public class InternshipManager : MonoBehaviour
{
    [SerializeField] private List<InternshipQuestion> questions; // 全ての質問のリスト
    [SerializeField] private Text questionText; // 現在の質問を表示するUIテキスト
    [SerializeField] private List<Button> answerButtons; // 回答用のボタンのリスト（3つのボタンが期待される）

    private List<InternshipQuestion> chosenQuestions; // 選択された質問のリスト
    private int currentQuestionIndex = 0; // 現在の質問のインデックス

    [SerializeField, Header("カンパニーインフォマネージャー")]
    CompanyInfoManager companyInfoManager; // 会社情報マネージャー

    [SerializeField, Header("ゲームマネージャー")]
    GameManager gameManager;

    [SerializeField, Header("会社ごとの経験値加算数値")]
    private int[] companyIenceStatus;

    [SerializeField, Header("経験値を表示するテキスト")]
    private Text IenceStatusText;

    [SerializeField, Header("回答後に消したいCanvas")]
    private GameObject[] canvasGrupe;

    void Start()
    {
        InitializeQuestions(); // 質問の初期化
        DisplayQuestion(); // 質問の表示
        OnIenceStatusText();
    }

    private void OnIenceStatusText()
    {
        IenceStatusText.text = GameManager.Instance.jobHuntingExperienceStatus.ToString();
    }

    // 質問の初期化
    private void InitializeQuestions()
    {
        // ランダムに5つの質問を選択
        chosenQuestions = new List<InternshipQuestion>();
        List<InternshipQuestion> shuffledQuestions = new List<InternshipQuestion>(questions);
        while (chosenQuestions.Count < 5 && shuffledQuestions.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, shuffledQuestions.Count);
            chosenQuestions.Add(shuffledQuestions[index]);
            shuffledQuestions.RemoveAt(index);
        }
    }

    // 質問の表示
    private void DisplayQuestion()
    {
        if (currentQuestionIndex < chosenQuestions.Count)
        {
            InternshipQuestion question = chosenQuestions[currentQuestionIndex];
            questionText.text = question.question; // 質問文を表示

            // 回答ボタンの設定
            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (i < question.answers.Count)
                {
                    answerButtons[i].gameObject.SetActive(true); // ボタンを表示
                    answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i].answerText; // ボタンに回答文を表示
                    int experienceGain = question.answers[i].experiencePoints; // 経験値を取得

                    // 以前のリスナーを全て削除してから新しいリスナーを追加
                    answerButtons[i].onClick.RemoveAllListeners();
                    answerButtons[i].onClick.AddListener(() => AnswerQuestion(experienceGain));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); // ボタンを非表示
                }
            }
        }
        else
        {
            // 全ての質問が回答された場合、インターンシップフェーズの終了を処理
            Debug.Log("すべての回答が終わりました"); // インターンシップフェーズが完了したことをログに表示

            // 必要に応じて次のフェーズに移行したり結果を表示したりする
            gameManager.UpdateStatusDisplay();
            OffCanvas();
        }
    }

    private void OffCanvas()
    {
        //ここにCanvasを非表示にするスクリプトをかく
        for (int i = 0; i < canvasGrupe.Length; i++)
        {
            canvasGrupe[i].SetActive(false);
        }
    }

    // 質問に対する回答処理
    private void AnswerQuestion(int experienceGain)
    {
        GameManager.Instance.jobHuntingExperienceStatus += experienceGain * companyIenceStatus[companyInfoManager.slectcomp]; // 経験値を加算
        OnIenceStatusText();
        currentQuestionIndex++; // 次の質問のインデックスへ
        DisplayQuestion(); // 次の質問を表示するか終了する
    }
}
