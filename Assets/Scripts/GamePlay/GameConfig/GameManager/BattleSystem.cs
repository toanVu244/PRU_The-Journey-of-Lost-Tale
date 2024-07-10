using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN,ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject deadPanel;
    public GameObject victoryPanel;
/*    public GameObject combatPanel;*/
    public static BattleSystem instance;
    public TextMeshProUGUI dialogueText;

    public Animator animatior_S1;
    public Animator animatior_enemy;

    public Transform heroBattleStation;
    public Transform enemyBattleStation;

    public GameObject heroPerfab;
    public GameObject enemyPrefab;

    Unit heroUnit;
    Unit enemyUnit;

    public BattleHUD enemyHUD;
    public BattleHUD heroHUD;
    public BattleState state;
    public PlayerInventory playerInventory;
    public InventoryItem requiredItem;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    private void RemoveCloneSuffix(GameObject obj)
    {
        obj.name = obj.name.Replace("(Clone)", "").Trim();
        obj.name = obj.name.Replace("Battle", "").Trim();
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            this.gameObject.SetActive(false);
            victoryPanel.SetActive(true);
            Destroy(enemyUnit);
        }
        else if (state == BattleState.LOST)
        {
            deadPanel.SetActive(true);
        }
    }

    public void CloseVicPanel()
    {
        victoryPanel.SetActive(false);
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("Story1_Forest"))
        {
            SceneManager.LoadScene("CutScene_4");
        }
        else if (currentScene.Equals("Story1_Cave")){
            SceneManager.LoadScene("CutScene_6");
        }
    }

    public void PlayAgainScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void MoveToMain()
    {
        SceneManager.LoadScene("Title_Game");
    }

    IEnumerator SetUpBattle()
    {

        GameObject heroGO = Instantiate(heroPerfab, heroBattleStation);
        RemoveCloneSuffix(heroGO);
        heroUnit = heroGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        RemoveCloneSuffix(enemyGO);
        enemyUnit = enemyGO.GetComponent<Unit>();
        heroHUD.SetHUD(heroUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {       
        bool isDead = enemyUnit.TakeDamage(heroUnit.damage);
        dialogueText.text = "The attack is successful!";
        animatior_enemy.SetBool("isAttacked", true);
        enemyHUD.SetHp(enemyUnit.currentHP);
        yield return new WaitForSeconds(0.6f);
        animatior_enemy.SetBool("isAttacked", false);
        yield return new WaitForSeconds(2f);    
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerShot()
    {
        if (playerInventory.currentInventory.Contains(requiredItem))
        {
            requiredItem.Use();
            bool isDead = enemyUnit.TakeDamage(heroUnit.damage + 2);
            dialogueText.text = "The attack is successful!";
            animatior_enemy.SetBool("isShotted", true);
            enemyHUD.SetHp(enemyUnit.currentHP);
            yield return new WaitForSeconds(0.6f);
            animatior_enemy.SetBool("isShotted", false);
            yield return new WaitForSeconds(2f);
            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                StartCoroutine(EnemyTurn());
            }
        }   
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
        bool isDead = heroUnit.TakeDamage(enemyUnit.damage);
        animatior_S1.SetBool("isAttacked", true);
        heroHUD.SetHp(heroUnit.currentHP);
        yield return new WaitForSeconds(1.5f);
        animatior_S1.SetBool("isAttacked", false);      
        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    IEnumerator PlayerHeal()
    {
        heroUnit.Heal(5);

        heroHUD.SetHp(heroUnit.currentHP);
        dialogueText.text = "You feel renewed strength!";

        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerAttack());
    }

    public void OnShotButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerShot());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerHeal());
    }
}
