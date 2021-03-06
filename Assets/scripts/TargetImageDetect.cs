﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TargetImageDetect: MonoBehaviour, ITrackableEventHandler {

	
	

	
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			tracked = true;
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