using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    //Informações que serão preenchidas no Inspector
    [SerializeField] private Pool[] pool;

    //Dicionários que guardam as informações do pool
    private Dictionary<string, Queue<GameObject>> dicionarioPool = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> dicionarioPrefab = new Dictionary<string, GameObject>();

    public static PoolingSystem Instancia;

    private void Awake()
    {
        Instancia = this;
    }

    private void Start()
    {
        InicializaDicionario();
    }

    private void InicializaDicionario()
    {
        //Passa por cada pool criado pelo usuário para adicionar a chave e o Queue ao dicionário
        for (int i = 0; i < pool.Length; i++)
        {
            //Cria a fila
            Queue<GameObject> poolObjetos = new Queue<GameObject>();

            //Cria o primeiro objeto
            GameObject objeto = Instantiate(pool[i].Prefab);
            objeto.SetActive(false);
            poolObjetos.Enqueue(objeto);

            //Insere entrada nos dicionários
            dicionarioPool.Add(pool[i].Key, poolObjetos);
            dicionarioPrefab.Add(pool[i].Key, pool[i].Prefab);
        }
    }

    public GameObject GetObjeto(string key, Vector2 posicao, Quaternion rotacao)
    {
        //Checa se existe essa tag no dicionário
        if (!dicionarioPool.ContainsKey(key))
        {
            Debug.Log("Não contém " + key);
            return null;
        }

        //Verifica se existe um objeto no pool ou se ele está ativo
        if (dicionarioPool[key].Peek().activeSelf)
        {
            //Instancia um novo
            GameObject objetoPooled = Instantiate(dicionarioPrefab[key]);
            //Insere novo objeto no dicionário
            dicionarioPool[key].Enqueue(objetoPooled);
            //Retorna objeto
            return objetoPooled;
        }
        else
        {
            //Pega da fila
            GameObject objetoPooled = dicionarioPool[key].Dequeue();
            //Coloca o objeto na posição e rotação corretas
            objetoPooled.transform.position = posicao;
            objetoPooled.transform.rotation = rotacao;
            //Ativa objeto
            objetoPooled.SetActive(true);
            //Coloca de volta
            dicionarioPool[key].Enqueue(objetoPooled);
            //Retorna objeto
            return objetoPooled;
        }
    }

    //Classe que permite definir as variáveis no Inspector
    [System.Serializable]
    public class Pool
    {
        public string Key;
        public GameObject Prefab;
    }
}