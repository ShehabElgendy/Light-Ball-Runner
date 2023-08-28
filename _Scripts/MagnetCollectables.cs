using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollectables : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Collectables>(out Collectables collectables))
        {
            collectables.SetTarget(transform.parent.position);
        }
    }
}
