using UnityEngine;

public class HouseController : MonoBehaviour
{
    public bool _isDestination = false;
    public bool _isDelivered = false;
    public EventsController _eventsController;
    public GameObject _arrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isDelivered && _isDestination)
        {
            Delivery();
        }
    }

    private void Delivery()
    {
        _isDelivered = true;
        _eventsController.Delivery();
        _arrow.SetActive(false);
    }
}
