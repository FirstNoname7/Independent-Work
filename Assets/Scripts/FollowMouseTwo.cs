using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseTwo : MonoBehaviour
{
    // тут указана второй вариант как сделать, чтоб камера следила за игроком. Ќа примере 2-ой мыши, котора€ управл€етс€ стрелками. Ѕез использовани€ Cinemachine.
    //если хочешь посмотреть как Cinemachine действует, тогда деактивируй mousetwoCamera в »ерархии.
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
