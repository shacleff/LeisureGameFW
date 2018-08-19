using UnityEngine;

namespace Complete
{
    public class CameraControl : MonoBehaviour
    {
        public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.
        public float m_ScreenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
        public float m_MinSize = 6.5f;                  // The smallest orthographic size the camera can be.
        [HideInInspector] public Transform[] m_Targets; // All the targets the camera needs to encompass.


        private Camera m_Camera;                        // Used for referencing the camera.
        private float m_ZoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
        private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
        private Vector3 m_DesiredPosition;              // The position the camera is moving towards.


        private void Awake ()
        {
            m_Camera = GetComponentInChildren<Camera> ();
        }

        private void FixedUpdate ()
        {
            Move ();
            Zoom ();
        }

        private void Move ()
        {
            FindAveragePosition ();
            transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
        }
        
        /// <summary>
        /// 获取每个目标位置的平均值，目的是把相机放到其相应的中间位置
        /// </summary>
        private void FindAveragePosition ()
        {
            Vector3 averagePos = new Vector3 ();
            int numTargets = 0;
            
            for (int i = 0; i < m_Targets.Length; i++)
            {
                // If the target isn't active, go on to the next one.
                if (!m_Targets[i].gameObject.activeSelf)
                    continue;
                averagePos += m_Targets[i].position;
                numTargets++;
            }
            if (numTargets > 0)
                averagePos /= numTargets;
            averagePos.y = transform.position.y;
            m_DesiredPosition = averagePos;
        }


        private void Zoom ()
        {
            float requiredSize = FindRequiredSize();
            m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
        }

        /// <summary>
        /// 根据所需的位置找到所需的尺寸，并平稳过渡到这个尺寸。
        ///  Find the required size based on the desired position and smoothly transition to that size.
        ///  
        /// </summary>
        /// <returns></returns>
        private float FindRequiredSize ()
        {
            // Find the position the camera rig is moving towards in its local space.
            Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

            // Start the camera's size calculation at zero.
            float size = 0f;

            // Go through all the targets...
            for (int i = 0; i < m_Targets.Length; i++)
            {
                // ... and if they aren't active continue on to the next target.
                if (!m_Targets[i].gameObject.activeSelf)
                    continue;

                // Otherwise, find the position of the target in the camera's local space.在相机的局部空间找到目标位置
                Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);
                // Find the position of the target from the desired position of the camera's local space.从相机的局部空间的期望位置找到目标位置
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
                // Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

                // Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
            }

            // Add the edge buffer to the size.
            size += m_ScreenEdgeBuffer;

            // Make sure the camera's size isn't below the minimum.
            size = Mathf.Max (size, m_MinSize);

            return size;
        }


        public void SetStartPositionAndSize ()
        {
            // Find the desired position.
            FindAveragePosition ();

            // Set the camera's position to the desired position without damping.
            transform.position = m_DesiredPosition;

            // Find and set the required size of the camera.
            m_Camera.orthographicSize = FindRequiredSize ();
        }
    }
}