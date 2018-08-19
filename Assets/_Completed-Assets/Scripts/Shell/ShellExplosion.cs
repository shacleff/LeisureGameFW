using UnityEngine;

namespace Complete
{
    /// <summary>
    /// �ӵ���ը��
    /// </summary>
    public class ShellExplosion : MonoBehaviour
    {
        /// <summary>
        /// �������˱�ը��Ӱ�죬Ӧ������Ϊ����ҡ���
        /// </summary>
        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        /// <summary>
        /// ��ը��������
        /// </summary>
        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
        /// <summary>
        /// ��ը����
        /// </summary>
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        /// <summary>
        /// �����ը������һ��̹���ϣ�����ɵ��˺��̶ȡ�
        /// </summary>
        public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
        /// <summary>
        /// �ڱ�ը���ĵ�̹�������ӵ�����
        /// </summary>
        public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        /// <summary>
        /// Զ�뱬ը�޵�����������ǲ�����Ȼ�ܵ�Ӱ��
        /// </summary>
        public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.


        private void Start ()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy (gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter (Collider other)
        {
			// ��ȡ�����shpere��Χ�ڵ�������ײ��.
            Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();
                if (!targetRigidbody)
                    continue;
                
                targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();
                // If there is no TankHealth script attached to the gameobject, go on to the next collider.���û��TankHealth������̹�ˣ�����
                if (!targetHealth)
                    continue;

                // Calculate the amount of damage the target should take based on it's distance from the shell. ���ݾ������������ܵ����˺�ֵ
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
        /// ���ݾ������������ܵ����˺�ֵ
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