using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTwo : MonoBehaviour
{
    // ��� ������� ������ ������� ��� �������, ���� ������ ������� �� �������. �� ������� 2-�� ����, ������� ����������� ���������. ��� ������������� Cinemachine.
    //���� ������ ���������� ��� Cinemachine ���������, ����� ����������� mousetwoCamera � ��������.
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, -10);
    void Start()
    {
        
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
