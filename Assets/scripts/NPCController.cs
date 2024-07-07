using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform characterTransform; // Karakterin Transform bileşeni
    private SpriteRenderer spriteRenderer; // NPC'nin SpriteRenderer bileşeni

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer bileşeni bulunamadı!");
        }
    }

    void Update()
    {
        if (characterTransform != null)
        {
            // NPC'nin konumu
            float npcX = transform.position.x;

            // Karakterin konumu
            float characterX = characterTransform.position.x;

            // NPC'nin sağında mı solunda mı kontrol et
            if (characterX > npcX)
            {
                FlipCharacter(true); // NPC sola bakacak şekilde flip
            }
            else
            {
                FlipCharacter(false); // NPC sağa bakacak şekilde flip
            }
        }
    }

    void FlipCharacter(bool faceLeft)
    {
        // NPC'nin x eksenindeki yönünü tersine çevir
        spriteRenderer.flipX = faceLeft;
    }
}