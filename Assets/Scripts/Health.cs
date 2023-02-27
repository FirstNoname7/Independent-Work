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
                controller.renderer.material.SetColor("_Color", Color.white); //если мышь берёт аптечку (грызёт свечку), то помимо того, что ХП восстанавливается, мышь становится нормального цвета
                gameObject.SetActive(false); //тут я не удаляю объект, а деактивирую его, потому что хочу потом сделать, чтоб свечка появлялась 


            }

        }

    }
}
