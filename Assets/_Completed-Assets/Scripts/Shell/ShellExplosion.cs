using UnityEngine;

namespace Complete
{
    /// <summary>
    /// 子弹爆炸类
    /// </summary>
    public class ShellExplosion : MonoBehaviour
    {
        /// <summary>
        /// 用来过滤爆炸的影响，应该设置为“玩家”。
        /// </summary>
        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        /// <summary>
        /// 爆炸粒子引用
        /// </summary>
        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
        /// <summary>
        /// 爆炸声音
        /// </summary>
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        /// <summary>
        /// 如果爆炸集中在一个坦克上，所造成的伤害程度。
        /// </summary>
        public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
        /// <summary>
        /// 在爆炸中心的坦克上增加的力量
        /// </summary>
        public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        /// <summary>
        /// 远离爆炸罐的最大距离可以是并且仍然受到影响
        /// </summary>
        public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.


        private void Start ()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy (gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter (Collider other)
        {
			// 获取在这个shpere范围内的所以碰撞体.
            Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();
                if (!targetRigidbody)
                    continue;
                
                targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();
                // If there is no TankHealth script attached to the gameobject, go on to the next collider.如果没有TankHealth不属于坦克，忽略
                if (!targetHealth)
                    continue;

                // Calculate the amount of damage the target should take based on it's distance from the shell. 根据距离来计算所受到的伤害值
                float damage = CalculateDamage (targetRigidbody.position);
                targetHealth.TakeDamage (damage);
            }

            // Unparent the particles from the shell.
            m_ExplosionParticles.transform.parent = null;
            m_ExplosionParticles.Play();
            m_ExplosionAudio.Play();

            // Once the particles have finished, destroy the gameobject they are on.
            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy (m_ExplosionParticles.gameObject, mainModule.duration);
            // Destroy the shell.
            Destroy (gameObject);
        }

        /// <summary>
        /// 根据距离来计算所受到的伤害值
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        private float CalculateDamage (Vector3 targetPosition)
        {
            Vector3 explosionToTarget = targetPosition - transform.position;
            float explosionDistance = explosionToTarget.magnitude;
            float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
            float damage = relativeDistance * m_MaxDamage;
            damage = Mathf.Max (0f, damage);
            return damage;
        }
    }
}