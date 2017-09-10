using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMaster : MonoBehaviour {

	public static UIMaster Instance;
	public GameObject UIRootContainer;

	/// <summary>
	/// Main UI Stack 
	/// to do :override system stack 
	/// </summary>
	private Stack<UIViewController> mUIStack;
	/// <summary>
	/// stash UI Stack
	/// </summary>
	private Stack<UIViewController> mStashUIStack;

	public void Pop(UIViewController viewcontroller){
		Debug.Log("Pop:" + viewcontroller);
		mUIStack.Pop();
		viewcontroller.OnCloseView();
		if(mStashUIStack.Count > 0){
			mStashUIStack.Pop().OnShowView();
			UnityEngine.Debug.Log(mStashUIStack.Count);
		}
	}

	public void Push(UIViewController viewcontroller, UIType type){
		Debug.Log("Push:" + viewcontroller);

		if(type == UIType.Overlay){
				
		}

		if(type == UIType.Replace){
			var topviewcontroller = mUIStack.Peek();
			Stash(topviewcontroller);
		}
		mUIStack.Push(viewcontroller);	
		viewcontroller.UIViewControllerDidLoad();
	}

	public void Stash(UIViewController viewcontroller){
		Debug.Log("Stash:" + viewcontroller);
		mStashUIStack.Push(viewcontroller);
		viewcontroller.OnHideView();	
	}

	public void Clear()
	{
		mUIStack.Clear();
	}

	public MainUIViewController mainUIViewController;
	public NoticeUIViewController noticeUIViewController;

	void Awake(){
		Instance = this;	
		mUIStack = new Stack<UIViewController>();
		mStashUIStack = new Stack<UIViewController>();
		DontDestroyOnLoad(gameObject);

		//Load viewcontroller
		mainUIViewController = new MainUIViewController("DemoMainUIVIew");
		noticeUIViewController = new NoticeUIViewController("DemoNoticeUIView");
	}

	void Start(){
		Instance.Push(mainUIViewController, UIType.Overlay);
	}

	void OnDestory(){

		//Destory viewcontroller
		mainUIViewController.Destory();
		noticeUIViewController.Destory();
	}
}
