using UnityEngine;
using UnityEngine.UI;

public class PersonagemSlot : MonoBehaviour
{
    [SerializeField] private int indiceSlot;

    [SerializeField] private Sprite[] avatares;
    public static bool[] escolhido; //O "static" aqui faz com que se algum objeto alterar o valor dessa variável, todas as instâncias desse script na mesma cena vão ter as variáveis alteradas também
    private int avatarIndice;
    private int ultimoAvatarIndice;

    [SerializeField] private Image avatarImagem;

    private bool primeiraEscolha = true;

    private void Start()
    {
        escolhido = new bool[avatares.Length];
    }

    public void MudarPersonagem(int direcao)
    {
        if(ChecarAvatarDisponivel())
        {
            avatarIndice += direcao;

            //Verifica se o índice está fora do tamanho do array
            if(avatarIndice < 0)
            {
                avatarIndice = avatares.Length - 1;
            }
            //Verifica se o índice está fora do tamanho do array
            if (avatarIndice == avatares.Length)
            {
                avatarIndice = 0;
            }

            //Se o avatar não estiver sendo usado, ele faz a troca e registra o avatar novo
            if(!escolhido[avatarIndice])
            {
                avatarImagem.sprite = avatares[avatarIndice];
                escolhido[avatarIndice] = true;

                //Se for a primeira vez que o jogador está escolhendo um avatar, ele só marca que a primeira escolha acabou de ser feita
                if (primeiraEscolha)
                {
                    primeiraEscolha = false;
                }
                //Senão ele marca que o avatar escolhido antes desse está liberado para outros jogadores
                else
                {
                    escolhido[ultimoAvatarIndice] = false;
                }
                ultimoAvatarIndice = avatarIndice;

                //Salva o índice do personagem escolhido no PlayerPrefs
                PlayerPrefs.SetInt(string.Format("Personagem{0}", indiceSlot), avatarIndice);
            }
            //Senão ele chama essa função recursivamente até chegar no avatar livre
            else
            {
                MudarPersonagem(direcao);
            }
        }
    }

    //Verifica se o avatar já foi escolhido por outros jogadores
    public bool ChecarAvatarDisponivel()
    {
        for(int i = 0; i < avatares.Length; i++)
        {
            if(!escolhido[i])
            {
                return true;
            }
        }
        return false;
    }
}
