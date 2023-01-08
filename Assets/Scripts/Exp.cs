using UnityEngine;

public class Exp : MonoBehaviour
{
    public Player player;

    float desiredDuration = 3f;
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        if (player != null)
            transform.position = Vector3.Lerp(transform.position, player.transform.position, percentageComplete);

        GiveExp();
    }

    private void GiveExp()
    {
        if(transform.position == player.transform.position)
        {
            player.EarnXp();
            Destroy(gameObject);
        }
    }
}