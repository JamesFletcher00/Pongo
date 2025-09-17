using UnityEngine;
using System.Collections;

public class GoalLightsFlashing : MonoBehaviour
{
    public SpriteRenderer lightRenderer;
    public Color player1Color = Color.blue;
    public Color player2Color = Color.red;
    public Color defaultColor = Color.white;

    public float pulseDuration = 0.3f;
    public float pulseCount = 4f;

    public void Flash(Color flashColor)
    {
        StartCoroutine(FlashCoroutine(flashColor));
    }

    private IEnumerator FlashCoroutine(Color flashColor)
    {
        for (int i = 0; i < pulseCount; i++)
        {
            lightRenderer.color = flashColor;
            yield return new WaitForSeconds(pulseDuration);
            lightRenderer.color = defaultColor;
            yield return new WaitForSeconds(pulseDuration);
        }
    }
}
