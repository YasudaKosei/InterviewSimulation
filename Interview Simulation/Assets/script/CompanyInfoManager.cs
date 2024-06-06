using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CompanyInfo
{
    public string companyName;
    public int academic; // 学力ステータス
    public int communication; // コミュニケーション能力ステータス
    public int cooperation; // 協働ステータス
    public int responsibility; // 責任感ステータス
    public int proactivity; // 積極性ステータス
    public int jobHunting; // 就活経験ステータス
}

public class CompanyInfoManager : MonoBehaviour
{
    public CompanyInfo[] companies; // 企業情報の配列
    public Text[] companyTexts; // 各企業情報を表示するTextコンポーネントの配列
    public Text[] newCompanyTexts; // 新しいテキスト配列

    public int slectcomp; //現在選択中の会社番号

    [SerializeField, Header("ゲームマネージャー")]
    GameManager gameManager;

    [SerializeField, Header("ES通過キャンバス")]
    private GameObject ESpassCanvas;

    void Start()
    {
        if (companies.Length != companyTexts.Length || companies.Length != newCompanyTexts.Length)
        {
            Debug.LogError("会社情報とテキストの数が一致しません。");
            return;
        }

        for (int i = 0; i < companies.Length; i++)
        {
            companyTexts[i].text = $"{companies[i].companyName}\n" +
                                   $"学力ステータス: {companies[i].academic}\n" +
                                   $"コミュ力: {companies[i].communication}\n" +
                                   $"協働ステータス: {companies[i].cooperation}\n" +
                                   $"責任感ステータス: {companies[i].responsibility}\n" +
                                   $"積極性ステータス: {companies[i].proactivity}\n" +
                                   $"就活経験ステータス: {companies[i].jobHunting}";

            newCompanyTexts[i].text = $"{companies[i].companyName}\n" +
                                   $"学力ステータス: {companies[i].academic}\n" +
                                   $"コミュ力: {companies[i].communication}\n" +
                                   $"協働ステータス: {companies[i].cooperation}\n" +
                                   $"責任感ステータス: {companies[i].responsibility}\n" +
                                   $"積極性ステータス: {companies[i].proactivity}\n" +
                                   $"就活経験ステータス: {companies[i].jobHunting}";
        }
    }

    public void SelectCompany(int CompanyNum)
    {
        slectcomp = CompanyNum;
    }

    public void GoIntern()
    {
        if (!(companies[slectcomp].academic <= gameManager.academicStatus))
        {
            Debug.Log("学力ステータスを満たしていないのでインターンに参加できません");
            return;
        }
        if (!(companies[slectcomp].communication <= gameManager.communicationStatus))
        {
            Debug.Log("コミュ力を満たしていないのでインターンに参加できません");
            return;
        }
        if (!(companies[slectcomp].cooperation <= gameManager.cooperationStatus))
        {
            Debug.Log("協働ステータスを満たしていないのでインターンに参加できません");
            return;
        }
        if (!(companies[slectcomp].responsibility <= gameManager.responsibilityStatus))
        {
            Debug.Log("責任感ステータスを満たしていないのでインターンに参加できません");
            return;
        }
        if (!(companies[slectcomp].proactivity <= gameManager.proactivityStatus))
        {
            Debug.Log("積極性ステータスを満たしていないのでインターンに参加できません");
            return;
        }
        if (!(companies[slectcomp].jobHunting <= gameManager.jobHuntingExperienceStatus))
        {
            Debug.Log("就活経験ステータスを満たしていないのでインターンに参加できません");
            return;
        }

        //インターンに行く処理
        Debug.Log("インターンに参加できます");
        ESpassCanvas.SetActive(true);
    }
}