using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats HealthPoints;
    public CharacterStats Strength;

    public void IsDead()
    {
        if(HealthPoints.Value == 0)
        {
            Destroy(gameObject);
            if(gameObject.tag == "Player")
            {
                Debug.Log("Koniec Gry!");
            }
        }
    }
}
