using UnityEngine;

public class TesteDosDados : MonoBehaviour
{
    //Script da rolagem de dados
    [SerializeField] private RolagemDeDados rolagemDeDados;

    //Animators
    [SerializeField] private Animator dadoUmAnimator;
    [SerializeField] private Animator dadoDoisAnimator;

    //Resultados
    private int resultadoDadoUm;
    private int resultadoDadoDois;

    public void IniciaAnimacao()
    {
        dadoUmAnimator.enabled = true;
        dadoDoisAnimator.enabled = true;
    }

    public void ParaDados()
    {
        //Operações com o dado 1
        //Rola o resultado
        resultadoDadoUm = rolagemDeDados.RolarDado();
        //Desativa o animator para parar a animação
        dadoUmAnimator.enabled = false;
        //Reinicia a rotação do dado
        dadoUmAnimator.gameObject.transform.rotation = Quaternion.identity;
        //Rotaciona o dado para mostrar o resultado
        dadoUmAnimator.gameObject.transform.Rotate(rolagemDeDados.FaceDoDado(resultadoDadoUm));

        //Operações com o dado 2
        //Rola o resultado
        resultadoDadoDois = rolagemDeDados.RolarDado();
        //Desativa o animator para parar a animação
        dadoDoisAnimator.enabled = false;
        //Reinicia a rotãção do dado        
        dadoDoisAnimator.gameObject.transform.rotation = Quaternion.identity;
        //Rotaciona o dado para mostrar o resultado        
        dadoDoisAnimator.gameObject.transform.Rotate(rolagemDeDados.FaceDoDado(resultadoDadoDois));
    }
}