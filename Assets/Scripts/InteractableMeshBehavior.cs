using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMeshBehavior : MonoBehaviour {

	public GameObject contextMenu;
	public Material dissolveMaterial;
	public float fadeSpeedModifier = 1;
	public float contextMenuFadeInDelay = 0.25f;

	private Dictionary<Renderer, Material> rendMats = new Dictionary<Renderer, Material> ();
	private Material[] originalMaterials;
	private Renderer[] rends;
	private Collider collider;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		if (contextMenu == null)
			this.enabled = false;

		/*
		originalMaterials = gameObject.GetComponentsInChildren<Renderer> ().materials[0];
		rends = gameObject.GetComponentsInChildren<Renderer> ();
		*/

		foreach (Renderer rend in gameObject.GetComponentsInChildren<Renderer> ()) {
			rendMats.Add (rend, rend.sharedMaterial);
		}

		collider = GetComponent<Collider> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void FadeOut()
	{
		audioSource.Play ();
		StartCoroutine("FadeOutInternal");
	}

	public void FadeIn()
	{
		audioSource.Play ();
		StartCoroutine("FadeInInternal");
	}

	void OnBecameVisible()
	{
		collider.enabled = true;
		FadeIn ();
	}

	void OnBecameInvisible()
	{
		collider.enabled = false;
	}

	private IEnumerator FadeInInternal()
	{
		contextMenu.SetActive (true);
		CanvasRenderer[] canRend = contextMenu.GetComponentsInChildren<CanvasRenderer> ();

		foreach (Renderer rend in rendMats.Keys) {
			rend.enabled = true;
			rend.sharedMaterial = dissolveMaterial;
			rend.sharedMaterial.SetTexture ("_MainTex", rendMats[rend].GetTexture ("_MainTex"));
			// Set fully invisible at the beginning of a fade in
			rend.sharedMaterial.SetFloat ("_SliceAmount", 1.0f);
		}


		for (float f = 1f; f >= 0; f -= Time.deltaTime / fadeSpeedModifier)
		{
			foreach(CanvasRenderer c in canRend)
			{
				c.SetAlpha (1 - contextMenuFadeInDelay - f);
			}
			foreach (Renderer rend in rendMats.Keys) {
				rend.sharedMaterial.SetFloat ("_SliceAmount", f);
			}

			yield return null;
		}

		// Make shure context menu is fully visibily afterwards
		foreach(CanvasRenderer c in canRend)
		{
			c.SetAlpha (1);
		}

		foreach (Renderer rend in rendMats.Keys) {
			rend.sharedMaterial.SetFloat ("_SliceAmount", 1);

			rend.sharedMaterial = rendMats[rend];
		}
	}

	private IEnumerator FadeOutInternal()
	{
		CanvasRenderer[] canRend = contextMenu.GetComponentsInChildren<CanvasRenderer> ();

		foreach (Renderer rend in rendMats.Keys) {
			rend.sharedMaterial = dissolveMaterial;
			rend.sharedMaterial.SetTexture ("_MainTex", rendMats[rend].GetTexture ("_MainTex"));
			// Set fully invisible at the beginning of a fade in
			rend.sharedMaterial.SetFloat ("_SliceAmount", 1.0f);
		}

		for (float f = 0f; f <= 1; f += Time.deltaTime / fadeSpeedModifier)
		{
			foreach(CanvasRenderer c in canRend)
			{
				c.SetAlpha (1 - f);
			}
			foreach (Renderer rend in rendMats.Keys) {
				rend.sharedMaterial.SetFloat ("_SliceAmount", f);
			}

			yield return null;
		}
			
		contextMenu.SetActive (false);

		foreach (Renderer rend in rendMats.Keys) {
			rend.sharedMaterial = rendMats[rend];
			rend.enabled = false;
		}
		yield return null;
	}
}
