using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int point = 10;

    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player == null)
            return;

        player.Point += point;

        // แสดงจำนวน Point ปัจจุบัน
        UIManager.instance.UpdatePoint(player.Point);

        Destroy(gameObject);
    }
}