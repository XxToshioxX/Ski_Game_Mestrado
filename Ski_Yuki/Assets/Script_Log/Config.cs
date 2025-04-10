using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config : MonoBehaviour
{
	public string _local;
	public Text _localTexto;
	public Text _msg;

	// Use this for initialization
	void Start()
	{
		_local = Application.dataPath + "/" + "Log";
		_localTexto.text = _local;
	}

	// Update is called once per frame
	void Update()
	{
		_localTexto.text = _local;
	}

	public void ColocarMsg(string _texto)
	{
		_msg.text = _texto;
	}
}
