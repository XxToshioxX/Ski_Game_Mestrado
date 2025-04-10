using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CriarPasta : MonoBehaviour
{
    private Config _config;
    public Text _nome;

    // Start is called before the first frame update
    void Start()
    {
        _config = this.gameObject.GetComponent<Config>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _CriarPasta()
    {
        if (_nome.text != "")
        {
            if (Directory.Exists(_config._local + "/" + _nome.text) == false)
            {
                Directory.CreateDirectory(_config._local + "/" + _nome.text);
                _config.ColocarMsg("Pasta Crida Com Sucesso.");
            }
            else
            {
                _config.ColocarMsg("Erro Criar: Pasta ja Existe.");
            }
        }
        else
        {
            _config.ColocarMsg("Erro Criar: Nome Em Branco.");
        }
    }
}
