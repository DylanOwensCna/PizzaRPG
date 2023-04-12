using UnityEngine;

public class BorderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player enters the border, stop their movement
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.StopMovement();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If the player stays inside the border, do nothing
        if (collision.CompareTag("Player"))
        {
            return;
        }
    }
    public bool IsInsideBorder(Vector2 position) {
    // Check if the position is inside the border
    return GetComponent<Collider2D>().bounds.Contains(position);
}

}
