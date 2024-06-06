using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // �L�����o�X�̎Q��
    public GameObject mainCanvas;
    public GameObject internshipCanvas;

    // �{�^�������������ɌĂяo����郁�\�b�h
    public void ChangeToInternshipCanvas()
    {
        // ���C���L�����o�X���\���ɂ���
        mainCanvas.SetActive(false);
        // �C���^�[���V�b�v�L�����o�X��\������
        internshipCanvas.SetActive(true);
    }

    // ���������Ƀ��C���L�����o�X�̂ݕ\�����A���͔�\���ɂ���
    void Start()
    {
        mainCanvas.SetActive(true);
        internshipCanvas.SetActive(false);
    }
}
