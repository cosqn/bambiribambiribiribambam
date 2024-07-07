using UnityEngine;

public class OkKomutu : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        DusmanKontrol dusman = col.GetComponent<DusmanKontrol>();
        if (dusman != null)
        {
            dusman.TakeDamage(damage);
            Destroy(gameObject); // Ok'u yok et
        }
    }
}