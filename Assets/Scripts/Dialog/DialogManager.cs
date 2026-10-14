using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;


public class DialogManager : MonoBehaviour
{
	public static DialogManager Instance;

	public static bool dialogRunning;
	public static bool canAdvance;
	public static bool canTick;
	public static bool startDialog;
	public CanvasGroup canvasGroup;

	[SerializeField] private GameObject dialogPanel;
	[SerializeField] private TMP_Text dialogName;
	[SerializeField] private TMP_Text dialogText;
	[SerializeField] private GameObject continueArrow;
	private string[] textArray;
	private TextAsset textAsset;
	private int currentScreenCount = 0;
	private int totalScreenCount;
	private int speed = 1;
	private int maxChars = 300;
	private float tickSpeed = 0.005f;
	private string filePre;
	private int fileNum;
	private string fileName;


	void Awake()
	{
		dialogRunning = false;
		canAdvance = false;
		canTick = false;

		canvasGroup.alpha = 0;
		startDialog = true;

		filePre = "Dialog";
		fileNum = DialogTracker.fileNum;
		fileName = filePre + fileNum;

		textAsset = (TextAsset)Resources.Load("Dialog0");
		textArray = textAsset.text.Split('\n');
		totalScreenCount = textArray.Length;
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			Debug.Log("Dialog Reset");
			fileNum = 0;
			DialogTracker.fileNum = 0;
			fileName = filePre + fileNum;
		}

		if (Input.GetKeyDown(KeyCode.G) && startDialog)
		{
			StartDialog("ANY");
		}

		if ((Input.GetKeyDown(KeyCode.G) && canAdvance) || (Input.GetKeyDown(KeyCode.H) && canAdvance))
		{
			AdvanceDialog();
		}

		if (canTick)
		{
			if (Input.GetKeyDown(KeyCode.H))
			{
				speed = maxChars;
			}
		}
	}


	public void StartDialog(string npcName)
	{
		textAsset = (TextAsset)Resources.Load(fileName);
		textArray = textAsset.text.Split('\n');
		totalScreenCount = textArray.Length;

		if (fileNum != 7)
		{
			fileNum++;
			fileName = filePre + fileNum;
		}

		DialogTracker.fileNum = fileNum;
		canvasGroup.alpha = 1;
		startDialog = false;
		dialogRunning = true;
		StartCoroutine(TypeText());
	}


	void AdvanceDialog()
	{
		speed = 1;

		if (currentScreenCount < totalScreenCount - 1)
		{
			canAdvance = false;
			canTick = false;
			currentScreenCount++;
			StartCoroutine(TypeText());
		}
		else
		{
			dialogName.text = ""; dialogText.text = "";
			continueArrow.gameObject.SetActive(false);
			canvasGroup.alpha = 0;
			textArray = null; textAsset = null;
			currentScreenCount = 0; totalScreenCount = 0;
			canTick = false;
			canAdvance = false;
			dialogRunning = false;
			startDialog = true;
		}
	}


	IEnumerator TypeText()
	{
		continueArrow.gameObject.SetActive(false);
		dialogText.text = ""; dialogText.text = textArray[currentScreenCount];
		dialogText.ForceMeshUpdate();

		int totalVisibleCharacters = dialogText.textInfo.characterCount;
		int counter = 0;
		int visibleCount = 0;

		canTick = true;

		while (true)
		{
			visibleCount = counter % (totalVisibleCharacters + speed);
			dialogText.maxVisibleCharacters = visibleCount;

			if (visibleCount >= totalVisibleCharacters)
			{
				if (currentScreenCount <= totalScreenCount - 1)
				{
					continueArrow.gameObject.SetActive(true);
				}

				StopCoroutine(TypeText());
				canAdvance = true;
				canTick = false;
				yield break;
			}

			counter += speed;
			yield return new WaitForSeconds(tickSpeed);
		}
	}
}