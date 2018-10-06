using UnityEngine;
using System.Collections;

public class ShowPromoteDialog : MonoBehaviour {

	public void Show()
    {
        Timer.Schedule(this, 0.6f, () =>
        {
        });
    }
}
