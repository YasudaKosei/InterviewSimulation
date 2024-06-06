using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterviewManager : MonoBehaviour
{
    public Text resultText;  // ���ʕ\���p�̃e�L�X�g

    private void Start()
    {
        ShowResult();
    }

    private void ShowResult()
    {
        if (GameManager.Instance.academicStatus <= 300)
        {
            resultText.text = "���I�Ȃ�R���̌���\n�s���i�ł��B����̂������\n���F��\���グ�܂��B";
        }
        else
        {
            float chance = Random.Range(0f, 1f);
            if (chance < 0.2f)  // 20%�̊m���ŕs���i
            {
                resultText.text = "�s���I�Ȃ�R���̌���\n�s���i�ł��B����̂������\n���F��\���グ�܂��B";
            }
            else  // 80%�̊m���Ŏ��̑I�l�ւ̐i�o
            {
                resultText.text = "���߂łƂ��������܂��B\n���̑I�l�X�e�b�v��\n���i�݂�������";
            }
        }
    }
}
