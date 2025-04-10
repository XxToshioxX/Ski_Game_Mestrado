using UnityEngine;
using UnityEngine.UI;//Para Manipular as UIs
using System.IO;
using System.Collections;

public class ListarPasta : MonoBehaviour
{

	private Config _config;

	public string[] _pastas;

	public GameObject _btn;
	public Transform _painel;

	// Use this for initialization
	void Start()
	{
		_config = this.gameObject.GetComponent<Config>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void PegarPastas()
	{
		_pastas = Directory.GetDirectories(_config._local);

		foreach (Transform btn in _painel)
		{
			GameObject.Destroy(btn.gameObject);
		}

		foreach (var item in _pastas)
		{
			GameObject btn = Instantiate(_btn);
			btn.GetComponentInChildren<Text>().text = item;
			btn.transform.SetParent(_painel);
		}
	}

}
