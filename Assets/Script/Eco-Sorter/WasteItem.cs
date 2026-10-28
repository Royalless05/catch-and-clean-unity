    using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WasteItem : GameEntity
{

    [SerializeField] protected int pointValue = 10;
    [SerializeField] protected float fallSpeed = 2f;
    [SerializeField] protected AudioClip collectSound;
    [SerializeField, Range(0f, 1f)] protected float soundVolume = 1f;
    [SerializeField] protected int xpValue = 5;

    protected string info = "Sampah terkumpul";
    protected ScoreKeeper scoreKeeper;
    protected ProgressionSystem progression;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        progression = FindAnyObjectByType<ProgressionSystem>(); 
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f, Space.World);
        if(transform.position.y < -6f)
        {
            scoreKeeper.AddMissed();
            Remove();
        }
    }

    void OnMouseDown()
    {
        Collect();
    }
    protected virtual void Collect()
    {
        if(collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position, soundVolume);
        Debug.Log(info);
        scoreKeeper.AddPoints(pointValue, info);
        BeriXP();
        Remove();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouchPlayer(other.gameObject);
        }
    }


    protected virtual void OnTouchPlayer(GameObject player)
    {
        Collect();
    }

    protected virtual int HitungXP()
    {
        return xpValue;
    }

    public virtual void TerapkanLevel(int level)
    {
        fallSpeed = fallSpeed * (1f + 0.1f * (level - 1));
    }

    protected void BeriXP()
    {
        if(progression == null) return;
        progression.AddXP(HitungXP());
    }

}
