using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class RenomearPasta : MonoBehaviour
{

	private Config _config;
	public Text _nome;
	public Text _novoNome;

	// Use this for initialization
	void Start()
	{
		_config = this.gameObject.GetComponent<Config>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void _RenomearPasta()
	{
		if (_nome.text != "" && _novoNome.text != "")
		{
			if (Directory.Exists(_config._local + "/" + _nome.text))
			{
				Directory.Move(_config._local + "/" + _nome.text, _config._local + "/" + _novoNome.text);
				_config.ColocarMsg("Pasta Renomeada Com Sucesso");
			}
			else
			{
				_config.ColocarMsg("Erro Renomear: Pasta ja Renomeada ou nao existe.");
			}
		}
		else
		{
			_config.ColocarMsg("Erro Renomear: Nome ou novo Nome em branco.");
		}
	}

}
