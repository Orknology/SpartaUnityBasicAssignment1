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

    //TODO NPCŰ���� �����صΰ� �ش��ϴ� ���� �ҷ����� ����� �� �� �����ؼ� NPC�� �ø� �� ���� ��. ������ �̷��Ը�...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�÷��̾ �ƴ� ���� isTrigger�� �� �����ϱ� ����
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
