using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Signal : MonoBehaviour {
    
    private new CircleCollider2D collider;

    public float thetaScale = 0.01f;
    public float speed = 1;
    public float dissipateTime = 1;

    public Color upColor;
    public Color leftColor;
    public Color rightColor;
    public Color downColor;
    public Color fireColor;
    public Color respawnColor;

    private float dissipateScale;
    private float radius = 0f;
    private int size;
    private LineRenderer lineDrawer;
    private float theta = 0f;
    private bool dissipating = false;
    private float signalWidth = 0.2f;

    public Message Message { get; private set; }

    public void Init(Message message) {
        Message = message;
        lineDrawer = GetComponent<LineRenderer>();
        dissipateScale = dissipateTime / signalWidth;
        
        switch (message.command)
        {
            case Message.Command.Up:
                lineDrawer.material.color = upColor;
                break;
            case Message.Command.Left:
                lineDrawer.material.color = leftColor;
                break;
            case Message.Command.Right:
                lineDrawer.material.color = rightColor;
                break;
            case Message.Command.Down:
                lineDrawer.material.color = downColor;
                break;
            case Message.Command.Fire:
                speed *= 0.33f;
                lineDrawer.material.color = fireColor;
                break;
            case Message.Command.Respawn:
                speed *= 0.85f;
                lineDrawer.material.color = respawnColor;
                break;
            default:
                break;
        }
    }

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        Destroy(gameObject, 10);
    }

    void Update()
    {
        IncreaseRadius();
        if (!dissipating) return;
        
        signalWidth -= Time.deltaTime / dissipateScale;
        if (signalWidth <= 0)
        {
            Destroy(gameObject);
            return;
        }
        
        lineDrawer.startWidth = signalWidth;
        lineDrawer.endWidth = signalWidth;
    }

    private void IncreaseRadius()
    {
        radius += speed * Time.deltaTime;
        collider.radius = radius;
        theta = 0f;
        size = (int)((1f / thetaScale) + 1f);
        lineDrawer.positionCount = size + 5;
        for (int i = 0; i < size + 5; i++)
        {
            theta += (2.0f * Mathf.PI * thetaScale);
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            lineDrawer.SetPosition(i, new Vector3(x, y, 0) + transform.position);
        }
    }

    public void Dissipate()
    {
        lineDrawer.material.color = Color.gray;
        dissipating = true;
    }
}
