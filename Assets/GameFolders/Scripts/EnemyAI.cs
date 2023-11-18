using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Oyuncu objesinin Transform bileşeni
    public float moveSpeed = 5f; // Düşmanın hareket hızı
    public float attackRange = 3f; // Saldırı mesafesi
    public float stopChaseRange = 8f; // Takip etmeyi bırakma mesafesi
    public float attackCooldown = 2f; // Saldırı aralığı (saniye)
    public float EnemyHealt = 10;
    private float attackTimer = 0f;

    void Update()
    {
        player = PlayerC.Instance.transform;
        // Oyuncuya doğru yönelme
        Vector3 directionToPlayer = player.position - transform.position;

        if (directionToPlayer.magnitude < stopChaseRange)
        {
            transform.Translate(directionToPlayer.normalized * moveSpeed * Time.deltaTime, Space.World);

            // Saldırı zamanlayıcısını güncelleme
            attackTimer += Time.deltaTime;

            // Oyuncu saldırı mesafesinde ve saldırı aralığına ulaşıldığında saldır
            if (directionToPlayer.magnitude < attackRange && attackTimer >= attackCooldown)
            {
                AttackPlayer();
                attackTimer = 0f; // Zamanlayıcıyı sıfırla
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            EnemyHealt-=2;
            if (EnemyHealt <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void AttackPlayer()
    {
        // Burada oyuncuya saldırma işlemleri gerçekleştirilebilir.
        // Örneğin, oyuncuya zarar verme veya başka bir eylem gerçekleştirme.
        Debug.Log("Düşman saldırıyor!");
        PlayerC.Instance.PlayerHealt -= 5;
    }
}