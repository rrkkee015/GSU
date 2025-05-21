using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RectTransform hpPanel; // 좌측 하단에 위치한 패널
    public GameObject filledRectPrefab; // Sprite Square + Image(흰색)
    public GameObject emptyRectPrefab;  // Sprite Square + Image(투명+Outline)
    public float spacing = 8f;

    private List<GameObject> hpRects = new List<GameObject>();

    void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.onHPChanged += UpdateHPUI;
            UpdateHPUI(playerHealth.currentHP, playerHealth.maxHP);
        }
    }

    public void UpdateHPUI(int current, int max)
    {
        foreach (var go in hpRects)
            Destroy(go);
        hpRects.Clear();

        for (int i = 0; i < max; i++)
        {
            GameObject prefab = (i < current) ? filledRectPrefab : emptyRectPrefab;
            GameObject rect = Instantiate(prefab, hpPanel);
            RectTransform rt = rect.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * (rt.sizeDelta.x + spacing), 0);
            hpRects.Add(rect);
        }
    }
}