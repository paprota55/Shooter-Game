using UnityEngine;
using UnityStandardAssets._2D;

public class Player : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField]
    private StatusUI status;

    public int atitudeLimitToDie = -10;
    void Update()
    {
        if(transform.position.y <= -20)
        {
            DamagePlayer(playerStats.CurrentHealth);
        }

        if (status != null)
        {
            status.UpdateHealth(playerStats.CurrentHealth, playerStats.MaxHealth);
        }
    }

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

    private void UpdatePosition(PlayerMemory mem)
    {
        this.transform.position = new Vector3(mem.pos[0], mem.pos[1], mem.pos[2]);
    }

    void RegenHealth()
    {
        if(playerStats.MaxHealth > playerStats.CurrentHealth)
        playerStats.CurrentHealth += playerStats.Regen;
    }

    private void Start()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SavedData");
        playerStats = PlayerStats.instance;
        if (save != null)
        {
            UpdatePosition(DataManager.LoadPlayer());
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
