using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class DeletarPasta : MonoBehaviour
{

	private Config _config;
	public Text _nome;

	// Use this for initialization
	void Start()
	{
		_config = this.gameObject.GetComponent<Config>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void _DeletarPasta()
	{
		if (_nome.text != "")
		{
			if (Directory.Exists(_config._local + "/" + _nome.text) == true)
			{
				Directory.Delete(_config._local + "/" + _nome.text);
				_config.ColocarMsg("Pasta Deletada com Sucesso.");
			}
			else
			{
				_config.ColocarMsg("Erro Deletar: Pasta ja Deleteda ou nao foi criada.");
			}
		}
		else
		{
			_config.ColocarMsg("Erro Deletar: Nome em Branco.");
		}
	}

}
