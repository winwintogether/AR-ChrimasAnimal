using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TargetImageDetect: MonoBehaviour, ITrackableEventHandler {

	public GameObject mMainCamera;
	public GameObject mImages;
	public GameObject mLogo;
	public float mDuration;

	private TrackableBehaviour mTrackableBehaviour;
	bool tracked = false;


	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
		mDuration = 0;
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			tracked = true;
		} else {
			tracked = false;
		}

	}

	public void Update()
	{
		if (tracked) {
			mMainCamera.SetActive (true);
			mImages.SetActive (true);
			mLogo.SetActive (false);
			mDuration = 1.0F;
		} else if(mDuration>0 && !tracked){
		
			mDuration -= Time.deltaTime;
			if (mDuration < 0) {
				//mMainCamera.SetActive (false);
				Scene scene=SceneManager.GetActiveScene();
				SceneManager.LoadScene (scene.name);
			}

		}
	}
}