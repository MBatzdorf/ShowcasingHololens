using System;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

// Taken and adapted from https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_101e
// and https://developer.microsoft.com/en-us/windows/mixed-reality/holograms_211

public class GestureManager : MonoBehaviour {

	// Singleton instance of this class
	public static GestureManager Instance { get; private set; }

	public GestureRecognizer NavigationRecognizer { get; private set; }

    public bool IsNavigating { get; private set; }
    public Vector3 NavigationPosition { get; private set; }

    void Awake()
    {
        Instance = this;

        NavigationRecognizer = new GestureRecognizer();
        NavigationRecognizer.SetRecognizableGestures(
            GestureSettings.Tap |
            GestureSettings.NavigationX |
            GestureSettings.NavigationY |
            GestureSettings.NavigationZ);

        NavigationRecognizer.TappedEvent += OnTapped;
        NavigationRecognizer.NavigationStartedEvent += OnStarted;
        NavigationRecognizer.NavigationUpdatedEvent += OnUpdated;
        NavigationRecognizer.NavigationCompletedEvent += OnCompleted;
        NavigationRecognizer.NavigationCanceledEvent += OnCanceled;
    }

    void OnDestroy()
    {
        NavigationRecognizer.TappedEvent -= OnTapped;

        NavigationRecognizer.NavigationStartedEvent -= OnStarted;
        NavigationRecognizer.NavigationUpdatedEvent -= OnUpdated;
        NavigationRecognizer.NavigationCompletedEvent -= OnCompleted;
        NavigationRecognizer.NavigationCanceledEvent -= OnCanceled;

       
    }

    private void OnTapped(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        GameObject focusedObject = InteractibleManager.Instance.FocusedGameObject;

        if (focusedObject != null)
        {
            focusedObject.SendMessageUpwards("OnSelect");
        }
    }

    private void OnStarted(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        IsNavigating = true;
        NavigationPosition = normalizedOffset;
    }

    private void OnUpdated(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        IsNavigating = true;
        NavigationPosition = normalizedOffset;
    }

    private void OnCompleted(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        IsNavigating = false;
    }

    private void OnCanceled(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
    {
        IsNavigating = false;
    }
}
