using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerHPUIRect : MonoBehaviour
{
    public enum RectType { Filled, Empty }
    public RectType rectType;

    void Start()
    {
        var image = GetComponent<Image>();
        if (rectType == RectType.Filled)
        {
            image.color = Color.white;
            image.type = Image.Type.Sliced;
        }
        else
        {
            image.color = new Color(1,1,1,0); // 투명
            image.type = Image.Type.Sliced;
            // Outline 추가
            var outline = GetComponent<Outline>();
            if (outline == null)
            {
                outline = gameObject.AddComponent<Outline>();
                outline.effectColor = Color.white;
                outline.effectDistance = new Vector2(2, 2);
            }
        }
    }
}