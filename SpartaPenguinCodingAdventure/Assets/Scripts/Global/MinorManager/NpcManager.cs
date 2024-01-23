using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    public GameObject NPCPanel;

    //TODO NPC키값을 저장해두고 해당하는 값을 불러오는 방법을 좀 더 공부해서 NPC를 늘릴 수 있을 것. 지금은 이렇게만...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 아닌 것이 isTrigger될 때 제외하기 위해
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            NPCPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            NPCPanel.SetActive(false);
        }
    }
}
