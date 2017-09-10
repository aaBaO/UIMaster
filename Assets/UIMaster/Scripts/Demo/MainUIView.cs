using System;
using UnityEngine;
using UnityEngine.UI;

public class MainUIView : UIView{

	public Button addView;

	void Start(){
		addView.onClick.AddListener(OnClick_AddView);
	}

	private void OnClick_AddView(){
		UIMaster.Instance.Push(UIMaster.Instance.noticeUIViewController, UIType.Replace);
	}

	public override void ShowView(){
		base.ShowView();	
		Debug.Log("on Main ui view show");	
	}

	public override void HideView(){
		base.HideView();
	}
}

