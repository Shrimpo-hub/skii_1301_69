using UnityEngine;

public class Tree : MonoBehaviour
{
    private MeshRenderer rd;

    [SerializeField] private float knockbackForce = 5f;

    void Start()
    {
        rd = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rd.material.color = Color.red;

        Player player = collision.gameObject.GetComponent<Player>();

        if (player == null)
            return;

        // =========================
        // Knockback
        // =========================
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // ทิศจากต้นไม้ -> Player
            Vector3 knockbackDirection =
                (collision.transform.position - transform.position).normalized;

            // ไม่ให้เด้งขึ้น/ลง
            knockbackDirection.y = 0;

            rb.AddForce(
                knockbackDirection * knockbackForce,
                ForceMode.Impulse
            );
        }

        // =========================
        // Damage
        // =========================
        player.HP -= 15;

        UIManager.instance.ShowNotiText(
            $"Hurt -15\nHP: {player.HP}"
        );

        if (player.HP <= 0)
        {
            player.HP = 0;

            UIManager.instance.ShowNotiText(
                $"You Are DEAD!!!\n Points: {player.Point}"
            );
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rd.material.color = new Color32(109, 58, 22, 255);
    }
}