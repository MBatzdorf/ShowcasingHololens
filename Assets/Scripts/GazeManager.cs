using UnityEngine;
using Academy.HoloToolkit.Unity;

// Taken and adapted from https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_101e

public class GazeManager : MonoBehaviour {

	// Singleton instance of this class
	public static GazeManager Instance { get; private set; }
    [Tooltip("Maximum gaze distance for calculating a hit.")]
    public float MaxGazeDistance = 5.0f;

    [Tooltip("Select the layers raycast should target.")]
    public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;

    /// <summary>
    /// Physics.Raycast result is true if it hits a Hologram.
    /// </summary>
    public bool Hit { get; private set; }

    /// <summary>
    /// HitInfo property gives access
    /// to RaycastHit public members.
    /// </summary>
    public RaycastHit HitInfo { get; private set; }

    /// <summary>
    /// Position of the user's gaze.
    /// </summary>
    public Vector3 Position { get; private set; }

    /// <summary>
    /// RaycastHit Normal direction.
    /// </summary>
    public Vector3 Normal { get; private set; }

    private GazeStabilizer gazeStabilizer;
    private Vector3 gazeOrigin;
    private Vector3 gazeDirection;

    void Awake()
    {
        Instance = this;
        gazeStabilizer = GetComponent<GazeStabilizer>();
    }

    private void Update()
    {
        gazeOrigin = Camera.main.transform.position;

        gazeDirection = Camera.main.transform.forward;

        gazeStabilizer.UpdateHeadStability(gazeOrigin, Camera.main.transform.rotation);

        gazeOrigin = gazeStabilizer.StableHeadPosition;

        UpdateRaycast();
    }

    /// <summary>
    /// Calculates the Raycast hit position and normal.
    /// </summary>
    private void UpdateRaycast()
    {
        RaycastHit hitInfo;

        Hit = Physics.Raycast(gazeOrigin,
                       gazeDirection,
                       out hitInfo,
                       MaxGazeDistance,
                       RaycastLayerMask);

        HitInfo = hitInfo;

        if (Hit)
        {
            // If raycast hit a hologram...

            Position = hitInfo.point;
            Normal = hitInfo.normal;
        }
        else
        {
            // If raycast did not hit a hologram...
            // Save defaults ...
            Position = gazeOrigin + (gazeDirection * MaxGazeDistance);
            Normal = gazeDirection;
        }
    }
}
