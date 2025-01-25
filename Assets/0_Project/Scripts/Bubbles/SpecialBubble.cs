using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBubble : BubbleBase
{
    [SerializeField] private Color marijuanaColor = Color.white;
    [SerializeField] private Color alcoholColor = Color.white;
    [SerializeField] private Color heroineColor = Color.white;
    [SerializeField] private Color cosbyColor = Color.white;
    [SerializeField] private Color viagraColor = Color.white;
    [Space]
    [SerializeField] private List<Renderer> renderers;

    ESpecialBubble special = ESpecialBubble.Marijuana;

    public void SetSpecial(ESpecialBubble special)
    {
        this.special = special;

        Color color = GetColor(special);

        foreach (Renderer renderer in renderers)
        {
            List<Material> mats = new List<Material>();
            renderer.GetMaterials(mats);

            foreach (Material mat in mats)
            {
                var currColor = mat.GetColor("_BaseColor");
                color.a = currColor.a;
                mat.SetColor("_BaseColor", color);
            }
        }
    }

    private Color GetColor(ESpecialBubble special)
    {
        switch (special)
        {
            case ESpecialBubble.Marijuana:
                return marijuanaColor;
            case ESpecialBubble.Alcohol:
                return alcoholColor;
            case ESpecialBubble.Heroine:
                return heroineColor;
            case ESpecialBubble.Cosby:
                return cosbyColor;
            case ESpecialBubble.Viagra:
                return viagraColor;
            default:
                return marijuanaColor;
        }
    }
}