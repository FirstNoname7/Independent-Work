using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        MouseController controller = other.GetComponent<MouseController>();
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                controller.renderer.material.SetColor("_Color", Color.white); //���� ���� ���� ������� (����� ������), �� ������ ����, ��� �� �����������������, ���� ���������� ����������� �����
                gameObject.SetActive(false); //��� � �� ������ ������, � ����������� ���, ������ ��� ���� ����� �������, ���� ������ ���������� 


            }

        }

    }
}
