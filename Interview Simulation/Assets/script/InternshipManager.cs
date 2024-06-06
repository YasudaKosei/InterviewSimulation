using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

// �C���^�[���V�b�v�̎����\���N���X
[Serializable]
public class InternshipQuestion
{
    public string question; // ���╶
    public List<InternshipAnswer> answers; // �񓚂̃��X�g
}

// �C���^�[���V�b�v�̉񓚂�\���N���X
[Serializable]
public class InternshipAnswer
{
    public string answerText; // �񓚕�
    public int experiencePoints; // �o���l
}

public class InternshipManager : MonoBehaviour
{
    [SerializeField] private List<InternshipQuestion> questions; // �S�Ă̎���̃��X�g
    [SerializeField] private Text questionText; // ���݂̎����\������UI�e�L�X�g
    [SerializeField] private List<Button> answerButtons; // �񓚗p�̃{�^���̃��X�g�i3�̃{�^�������҂����j

    private List<InternshipQuestion> chosenQuestions; // �I�����ꂽ����̃��X�g
    private int currentQuestionIndex = 0; // ���݂̎���̃C���f�b�N�X

    [SerializeField, Header("�J���p�j�[�C���t�H�}�l�[�W���[")]
    CompanyInfoManager companyInfoManager; // ��Џ��}�l�[�W���[

    [SerializeField, Header("�Q�[���}�l�[�W���[")]
    GameManager gameManager;

    [SerializeField, Header("��Ђ��Ƃ̌o���l���Z���l")]
    private int[] companyIenceStatus;

    [SerializeField, Header("�o���l��\������e�L�X�g")]
    private Text IenceStatusText;

    [SerializeField, Header("�񓚌�ɏ�������Canvas")]
    private GameObject[] canvasGrupe;

    void Start()
    {
        InitializeQuestions(); // ����̏�����
        DisplayQuestion(); // ����̕\��
        OnIenceStatusText();
    }

    private void OnIenceStatusText()
    {
        IenceStatusText.text = GameManager.Instance.jobHuntingExperienceStatus.ToString();
    }

    // ����̏�����
    private void InitializeQuestions()
    {
        // �����_����5�̎����I��
        chosenQuestions = new List<InternshipQuestion>();
        List<InternshipQuestion> shuffledQuestions = new List<InternshipQuestion>(questions);
        while (chosenQuestions.Count < 5 && shuffledQuestions.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, shuffledQuestions.Count);
            chosenQuestions.Add(shuffledQuestions[index]);
            shuffledQuestions.RemoveAt(index);
        }
    }

    // ����̕\��
    private void DisplayQuestion()
    {
        if (currentQuestionIndex < chosenQuestions.Count)
        {
            InternshipQuestion question = chosenQuestions[currentQuestionIndex];
            questionText.text = question.question; // ���╶��\��

            // �񓚃{�^���̐ݒ�
            for (int i = 0; i < answerButtons.Count; i++)
            {
                if (i < question.answers.Count)
                {
                    answerButtons[i].gameObject.SetActive(true); // �{�^����\��
                    answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i].answerText; // �{�^���ɉ񓚕���\��
                    int experienceGain = question.answers[i].experiencePoints; // �o���l���擾

                    // �ȑO�̃��X�i�[��S�č폜���Ă���V�������X�i�[��ǉ�
                    answerButtons[i].onClick.RemoveAllListeners();
                    answerButtons[i].onClick.AddListener(() => AnswerQuestion(experienceGain));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); // �{�^�����\��
                }
            }
        }
        else
        {
            // �S�Ă̎��₪�񓚂��ꂽ�ꍇ�A�C���^�[���V�b�v�t�F�[�Y�̏I��������
            Debug.Log("���ׂẲ񓚂��I���܂���"); // �C���^�[���V�b�v�t�F�[�Y�������������Ƃ����O�ɕ\��

            // �K�v�ɉ����Ď��̃t�F�[�Y�Ɉڍs�����茋�ʂ�\�������肷��
            gameManager.UpdateStatusDisplay();
            OffCanvas();
        }
    }

    private void OffCanvas()
    {
        //������Canvas���\���ɂ���X�N���v�g������
        for (int i = 0; i < canvasGrupe.Length; i++)
        {
            canvasGrupe[i].SetActive(false);
        }
    }

    // ����ɑ΂���񓚏���
    private void AnswerQuestion(int experienceGain)
    {
        GameManager.Instance.jobHuntingExperienceStatus += experienceGain * companyIenceStatus[companyInfoManager.slectcomp]; // �o���l�����Z
        OnIenceStatusText();
        currentQuestionIndex++; // ���̎���̃C���f�b�N�X��
        DisplayQuestion(); // ���̎����\�����邩�I������
    }
}
