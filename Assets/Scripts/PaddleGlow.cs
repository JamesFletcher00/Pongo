using UnityEngine;

public class PaddleGlow : MonoBehaviour
{
    public SpriteRenderer glowSprite;
    public float glowTime = 0.5;
    public int pulseCount = 3;

    public void PulseGlow()
    {
        StartCoroutine(GlowRoutine());
    }

    private IEnumerator GlowRoutine()
    {
        color originalColor = glowSprite.color;

        for (int i = 0; i < pulseCount; i++)
        {
            glowSprite.enabled = true;
            yield return new WaitForSeconds(glowTime);
            glowSprite.enabled = false;
            yield return new WaitForSeconds(glowTime);
        }
        
        glowSprite.color = originalColor;
    }
}
