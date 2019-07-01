using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int rngDamage = 1;

    private bool fadeAble = false;

    public static bool isBoss = false;

    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth;
        public int damageAbsorb;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set
            {
                _curHealth = Mathf.Clamp(value, 0, maxHealth);
            }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusInd;

    [SerializeField]
    private Object scriptToDestroy;

    public EnemyStats stats = new EnemyStats();

    private void Start()
    {
        FloatingTextController.Initialize();
        stats.Init();

        if (statusInd != null)
        {
            statusInd.SetHeath(stats.curHealth, stats.maxHealth);
        }
    }

    private void Update()
    {
        if (fadeAble == true)
        {
            FadeThis();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "arrow")
        {
            //Náhoda úderu
            if (isBoss == false)
            {
                rngDamage = Random.Range(stats.damageAbsorb, stats.damageAbsorb + 5);
            }
            else
            {
                rngDamage = Random.Range(stats.damageAbsorb, stats.damageAbsorb + 10);
            }
            DamageEnemy(rngDamage, other);
            FloatingTextController.CreateFloatingText(rngDamage.ToString(), transform);
        }
    }

    public void DamageEnemy(int _damage, Collider _other)
    {
        stats.curHealth -= _damage;
        statusInd.SetHeath(stats.curHealth, stats.maxHealth);
        Destroy(_other.gameObject);

        if (stats.curHealth <= 0 && isBoss == false)
        {
            //Znič šíp a nepřítele
            Destroy(_other.gameObject);

            Destroy(scriptToDestroy);
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
            fadeAble = true;
            Destroy(this.gameObject, 1.2f);
            fadeAble = false;
        }
        else if (stats.curHealth <= 0 && isBoss == true)
        {
            Destroy(_other.gameObject);
            FollowBossParts.amIDestroyed = true;
        }
    }

    private void FadeThis()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.01f;
        GetComponent<Renderer>().material.color = color;
    }
}
