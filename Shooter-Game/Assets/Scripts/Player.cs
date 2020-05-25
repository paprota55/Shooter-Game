using UnityEngine;
using UnityStandardAssets._2D;

///Class to manipulate player object
public class Player : MonoBehaviour
{
    ///Reference to instance from PlayerStats class
    private PlayerStats playerStats;
    ///Reference to object which display information
    [SerializeField]
    private StatusUI status;

    ///Variable which set lower boundary, if altitude is lower than set then kill player
    public int altitudeLimitToDie = -15;

    ///Update statusUI and check if player altitude is lower than
    void Update()
    {
        if(transform.position.y <= altitudeLimitToDie)
        {
            DamagePlayer(playerStats.CurrentHealth);
        }

        if (status != null)
        {
            status.UpdateHealth(playerStats.CurrentHealth, playerStats.MaxHealth);
        }
    }

    ///Method to decrease player health, change values in PlayerStats class and play sounds from AudioManager
    public void DamagePlayer(float damage)
    {
        int randomNumber = Random.Range(0, 1);
        if (randomNumber == 0)
        {
            AudioManager.manager.Play("PlayerHit1");
        }
        else
        {
            AudioManager.manager.Play("PlayerHit2");
        }
        playerStats.CurrentHealth -= damage;

        if(playerStats.CurrentHealth <= 0)
        {
            GameController.KillPlayer(this);
        }
    }


    ///Method which write data from loaded object to this object
    private void LoadData(PlayerMemory mem)
    {
        this.transform.position = new Vector3(mem.pos[0], mem.pos[1], mem.pos[2]);
    }

    void RegenHealth()
    {
        if(playerStats.MaxHealth > playerStats.CurrentHealth)
        playerStats.CurrentHealth += playerStats.Regen;
    }

    ///Method which is called with object create, if "SavedData" object is exsist then load data from file. Invoke method which will be repeating to end game.
    private void Start()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SavedData");
        playerStats = PlayerStats.instance;
        if (save != null)
        {
            LoadData(DataManager.LoadPlayer());
            save.GetComponent<GameActualization>().player = true;
        }
        else
        {
            playerStats.Respawn();
        }
        if (status != null)
        {
            status.UpdateHealth(playerStats.CurrentHealth, playerStats.MaxHealth);
        }
        InvokeRepeating("RegenHealth", playerStats.HealthRegenRate, playerStats.HealthRegenRate);
    }
}
