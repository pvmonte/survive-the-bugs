using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerScript : MonoBehaviour {
	public GameObject descriptionPanel;
	public Text[] panelText = new Text[6];

	private float atualFireRate;
	private float atualMachineGunTime;
	private float atualBoxRate;
	private float atualMaxBarrierHP;
	private float atualMaxHp;
	private float atualMaxBomb;
		
	// Update is called once per frame
	void Update () {
		atualFireRate = 0.8f - (0.08f * UpgradeTable.current.fireRate);
		atualMachineGunTime = 5 + (3 * UpgradeTable.current.machineGunTime);
		atualBoxRate = 5.0f + (2.0f * UpgradeTable.current.boxRate);
		atualMaxBarrierHP = 1.0f + UpgradeTable.current.maxBarrierHP;
		atualMaxHp = 2.0f + UpgradeTable.current.maxHP;
		atualMaxBomb = 1.0f - UpgradeTable.current.maxBomb;

		panelText[0].text = "Aumenta Frequencia de tiro. Afeta todas as armas. Atual: atira a cada " + atualFireRate.ToString() + " segundos."; //FireRate
		panelText[1].text = "Aumenta Duração da metralhadora. Atual: " + atualMachineGunTime.ToString() + " segundos."; //MachineGunTime
		panelText[2].text = "Aumenta Chance de aparecer uma caixa ao matar um inseto. Atual: " + atualBoxRate.ToString() + " segundos."; //BoxRate
		panelText[3].text = "Aumenta ao máximo de energia da barreira. Atual: " + atualMaxBarrierHP.ToString() + " pontos."; //MaxBarrierHP
		panelText[4].text = "Aumenta o máximo de vida do jogador. Atual: " + atualMaxHp.ToString() + " pontos."; //MaxHp
		panelText[5].text = "Aumenta o máximo de bombas guardadas. Atual: " + atualMaxBomb.ToString() + " bombas."; //MaxBomb


	}

	public void ShowHelp(){		
		GameController.current.buttonSrc.Play ();
		descriptionPanel.SetActive (true);
	}

	public void HideHelp(){
		GameController.current.buttonSrc.Play ();
		descriptionPanel.SetActive (false);
	}
}
