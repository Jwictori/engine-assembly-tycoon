using UnityEngine;

namespace EngineAssemblyTycoon.Core
{
    /// <summary>
    /// CameraController - Handles camera movement and zoom
    /// Allows player to pan around factory and zoom in/out
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        #region Settings
        [Header("Pan Settings")]
        [SerializeField] private float panSpeed = 10f;
        [SerializeField] private bool edgePanning = true;
        [SerializeField] private float edgePanBorder = 20f; // Pixels from screen edge
        
        [Header("Zoom Settings")]
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float minZoom = 5f;  // Zoomed out (see more)
        [SerializeField] private float maxZoom = 20f; // Zoomed in (see less)
        
        [Header("Bounds (Optional)")]
        [SerializeField] private bool useBounds = true;
        [SerializeField] private float minX = -15f;
        [SerializeField] private float maxX = 15f;
        [SerializeField] private float minY = -15f;
        [SerializeField] private float maxY = 15f;
        #endregion

        #region Private Fields
        private Camera cam;
        private Vector3 dragOrigin;
        private bool isDragging = false;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            HandleKeyboardPan();
            HandleMouseDrag();
            HandleEdgePan();
            HandleZoom();
        }
        #endregion

        #region Keyboard Pan (WASD / Arrow Keys)
        private void HandleKeyboardPan()
        {
            Vector3 move = Vector3.zero;
            
            // WASD or Arrow Keys
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                move.y += 1f;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                move.y -= 1f;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                move.x -= 1f;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                move.x += 1f;
            
            if (move != Vector3.zero)
            {
                move.Normalize();
                transform.position += move * panSpeed * Time.deltaTime;
                ClampPosition();
            }
        }
        #endregion

        #region Mouse Drag Pan (Middle Mouse or Right Click)
        private void HandleMouseDrag()
        {
            // Start drag
            if (Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(1)) // Middle or Right click
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
                isDragging = true;
            }
            
            // During drag
            if (isDragging)
            {
                Vector3 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector3 difference = dragOrigin - currentPos;
                
                transform.position += difference;
                ClampPosition();
            }
            
            // End drag
            if (Input.GetMouseButtonUp(2) || Input.GetMouseButtonUp(1))
            {
                isDragging = false;
            }
        }
        #endregion

        #region Edge Pan (Mouse at Screen Edge)
        private void HandleEdgePan()
        {
            if (!edgePanning) return;
            
            Vector3 move = Vector3.zero;
            Vector3 mousePos = Input.mousePosition;
            
            // Left edge
            if (mousePos.x < edgePanBorder)
                move.x -= 1f;
            // Right edge
            if (mousePos.x > Screen.width - edgePanBorder)
                move.x += 1f;
            // Bottom edge
            if (mousePos.y < edgePanBorder)
                move.y -= 1f;
            // Top edge
            if (mousePos.y > Screen.height - edgePanBorder)
                move.y += 1f;
            
            if (move != Vector3.zero)
            {
                move.Normalize();
                transform.position += move * panSpeed * Time.deltaTime;
                ClampPosition();
            }
        }
        #endregion

        #region Zoom (Mouse Wheel)
        private void HandleZoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            
            if (scroll != 0f)
            {
                // Orthographic camera uses 'size' for zoom
                if (cam.orthographic)
                {
                    float newSize = cam.orthographicSize - scroll * zoomSpeed;
                    cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
                }
                else
                {
                    // Perspective camera (not used in this game, but just in case)
                    Vector3 pos = transform.position;
                    pos.z += scroll * zoomSpeed;
                    pos.z = Mathf.Clamp(pos.z, -maxZoom, -minZoom);
                    transform.position = pos;
                }
            }
        }
        #endregion

        #region Position Clamping
        private void ClampPosition()
        {
            if (!useBounds) return;
            
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Focus camera on a specific world position
        /// </summary>
        public void FocusOnPosition(Vector3 targetPos, float zoomLevel = 10f)
        {
            Vector3 newPos = targetPos;
            newPos.z = transform.position.z; // Keep same Z
            transform.position = newPos;
            
            if (cam.orthographic)
            {
                cam.orthographicSize = Mathf.Clamp(zoomLevel, minZoom, maxZoom);
            }
            
            ClampPosition();
        }

        /// <summary>
        /// Reset camera to default position
        /// </summary>
        public void ResetCamera()
        {
            transform.position = new Vector3(0, 0, -10f);
            if (cam.orthographic)
            {
                cam.orthographicSize = 15f;
            }
        }
        #endregion

        #region Debug Gizmos
        private void OnDrawGizmos()
        {
            if (useBounds)
            {
                Gizmos.color = Color.yellow;
                
                // Draw bounds rectangle
                Vector3 bottomLeft = new Vector3(minX, minY, 0);
                Vector3 bottomRight = new Vector3(maxX, minY, 0);
                Vector3 topRight = new Vector3(maxX, maxY, 0);
                Vector3 topLeft = new Vector3(minX, maxY, 0);
                
                Gizmos.DrawLine(bottomLeft, bottomRight);
                Gizmos.DrawLine(bottomRight, topRight);
                Gizmos.DrawLine(topRight, topLeft);
                Gizmos.DrawLine(topLeft, bottomLeft);
            }
        }
        #endregion
    }
}
