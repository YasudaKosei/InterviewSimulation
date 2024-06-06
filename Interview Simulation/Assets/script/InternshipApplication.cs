using UnityEngine;
using UnityEngine.UI;

public class InternshipApplication : MonoBehaviour
{
    // UIで設定する必要のあるフィールド
    public GameManager gameManager; // GameManagerスクリプトへの参照
    public GameObject errorPanel; // 条件を満たさないときに表示するエラーパネル
    public Canvas internshipCanvas; // インターンシップキャンバスへの参照

    // ボタンが押されたときに呼び出されるメソッド
    public void OnApplyButtonClick()
    {
        // 最低ステータスを満たしているかチェック
        if (CanApplyToInternship())
        {
            // 条件を満たしていればインターンシップキャンバスに移動
            internshipCanvas.enabled = true;
        }
        else
        {
            // 条件を満たさなければエラーパネルを表示
            errorPanel.SetActive(true);
        }
    }

    // プレイヤーがインターンシップへの応募条件を満たしているかをチェックするメソッド
    private bool CanApplyToInternship()
    {
        // ここに各企業の最低ステータスとプレイヤーのステータスを比較するロジックを追加
        // 以下はダミーの条件チェックです
        if (gameManager.academicStatus >= 50 &&
            gameManager.communicationStatus >= 30 &&
            gameManager.cooperationStatus >= 20 &&
            gameManager.responsibilityStatus >= 40 &&
            gameManager.proactivityStatus >= 30 &&
            gameManager.jobHuntingExperienceStatus >= 20)
        {
            return true;
        }
        return false;
    }

    // エラーパネルを閉じるメソッド
    public void CloseErrorPanel()
    {
        errorPanel.SetActive(false);
    }

    void Start()
    {
        // ゲーム開始時にエラーパネルとインターンシップキャンバスを非表示にする
        errorPanel.SetActive(false);
        internshipCanvas.enabled = false;
    }
}
