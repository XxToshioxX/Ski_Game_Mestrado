using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI; //Para manipular as UIs

public class CriarArquivo : MonoBehaviour
{
    public Config _config;
    public Text _texto;
    public Text _nomeArquivo;

    // Start is called before the first frame update
    void Start()
    {
        _config = GameObject.Find("Canvas_Log").GetComponent<Config>();
    }

    public void NovoArquivo()
    {
        if (_nomeArquivo.text == "")
        {
            _config._msg.text = "Erro: Arquivo ja Existe ou Nome Do Arquivo Em Branco";
        }
        else
        {
			PlayerPrefs.SetString("Nome", _nomeArquivo.text);
			var _arquivo = File.CreateText(_config._local + "/" + _nomeArquivo.text + ".txt");
            _arquivo.WriteLine("Nome: " + PlayerPrefs.GetString("Nome") + "\n" + "Tempo: " + PlayerPrefs.GetString("Timer") + "\n" + "Velocidade Maxima Alcançada: " + PlayerPrefs.GetFloat("VelocidadeMax") + "\n" + "Erros: " + PlayerPrefs.GetInt("Batidas") + "\n" + "Data: " + System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + "\n" + "Observação: " + _texto.text);
            _arquivo.Close();
            _texto.text = "";
            _config._msg.text = "Arquivo Criado Com Sucesso.";
        }
    }

	public void AbrirArquivo()
	{
		if (_nomeArquivo.text != "")
		{
			if (File.Exists(_config._local + "/" + _nomeArquivo.text + ".txt"))
			{
				var _arquivo = File.OpenText(_config._local + "/" + _nomeArquivo.text + ".txt");
				_texto.text = _arquivo.ReadLine();
				_arquivo.Close();
				_config._msg.text = "Arquivo Carregado Com Sucesso.";
			}
			else
			{
				_config._msg.text = "Erro: Arquivo Nao Existe.";
			}
		}
		else
		{
			_config._msg.text = "Erro: Nome Do Arquivo Em Branco.";
		}
	}
	public void DeletarArquivo()
	{
		if (_nomeArquivo.text != "")
		{
			if (File.Exists(_config._local + "/" + _nomeArquivo.text + ".txt"))
			{
				File.Delete(_config._local + "/" + _nomeArquivo.text + ".txt");
				_config._msg.text = "Arquivo Deletado Com Sucesso.";
			}
			else
			{
				_config._msg.text = "Erro: Arquivo Nao Existe.";
			}
		}
		else
		{
			_config._msg.text = "Erro: Nome Do Arquivo Em Branco.";
		}
	}
}
