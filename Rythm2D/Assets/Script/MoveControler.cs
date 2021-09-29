using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
    [SerializeField] float step = 2;

    Vector3 moveX = new Vector3(1, 0, 0);
    Vector3 moveY = new Vector3(0, 1, 0);

    Vector3 target = default;
    // Start is called before the first frame update
    void Start()
    {
        target = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTargetPosition()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (h == 1)
        {
            target = this.transform.position + moveX;
            return;
        }

        if (h == -1)
        {
            target = this.transform.position - moveX;
            return;
        }

        if (v == 1)
        {
            target = this.transform.position + moveY;
            return;
        }

        if (v == -1)
        {
            target = this.transform.position - moveY;
            return;
        }
    }

    public void Move()
    {
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
}
