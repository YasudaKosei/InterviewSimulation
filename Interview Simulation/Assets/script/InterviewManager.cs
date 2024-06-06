using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterviewManager : MonoBehaviour
{
    public Text resultText;  // 結果表示用のテキスト

    private void Start()
    {
        ShowResult();
    }

    private void ShowResult()
    {
        if (GameManager.Instance.academicStatus <= 300)
        {
            resultText.text = "厳選なる審査の結果\n不合格です。今後のご活躍を\nお祈り申し上げます。";
        }
        else
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.2f)  // 20%の確率で不合格
            {
                resultText.text = "不厳選なる審査の結果\n不合格です。今後のご活躍を\nお祈り申し上げます。";
            }
            else  // 80%の確率で次の選考への進出
            {
                resultText.text = "おめでとうございます。\n次の選考ステップに\nお進みください";
            }
        }
    }
}
