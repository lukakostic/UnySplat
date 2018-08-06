using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGun : MonoBehaviour {
    public static Texture2D tex;
    public Material mat;
    public static System.Random r;
    public Rigidbody paintBall;

    public float shoot = 0.2f;
    float shootTimer = 0f;

	// Use this for initialization
	void Start () {
        r = new System.Random();
        tex = new Texture2D(1200, 1200);	
	}

    private void Update()
    {
        shootTimer += Time.deltaTime;
        
        if (Input.GetMouseButton(1))
        {
            if (shootTimer > shoot)
            {
                Rigidbody go = GameObject.Instantiate(paintBall, transform.position, transform.rotation) as Rigidbody;
                go.velocity = transform.forward * 15f;
                shootTimer = 0f;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetMouseButton(0))
        {
            PaintRay(Vector3.zero);
            float off = 0.3f;

            PaintMultiple(off);
            PaintMultiple(off / 2f);

            tex.Apply();
        }

        mat.SetTexture("_MainTex", tex);

    }
    public void PaintMultiple(float off)
    {
        PaintRay(new Vector2(off, off));
        PaintRay(new Vector2(-off, -off));
        PaintRay(new Vector2(off, -off));
        PaintRay(new Vector2(-off, off));
        PaintRay(new Vector2(0f, off));
        PaintRay(new Vector2(0f, -off));
        PaintRay(new Vector2(off, 0f));
        PaintRay(new Vector2(-off, 0f));
    }
    public void PaintRay(Vector2 offset)
    {
        if (r.Next(5) < 2) return; // Used to add more randomness

        RaycastHit rh;
        Physics.Raycast(transform.position+ transform.right*offset.x+transform.up*offset.y, transform.forward, out rh, 50f);

        if (rh.transform != null)
        {
            int x = (int)(rh.textureCoord.x * tex.width);
            int y = (int)(rh.textureCoord.y * tex.height);

            RandomBrush(x, y, 1, 2);

        }
    }

    public void RandomBrush(int x, int y, int taps, int radius)
    {
        for (int i = 0; i < (taps+1); i++)
        {
            float rx = (float)r.NextDouble()*(float)radius;

            Vector3 point = new Vector3(rx, 0,rx);
            int ry = r.Next(360);
            point = Quaternion.AngleAxis(ry, Vector3.up) * point;

            
            tex.SetPixel(x+(int)point.x, y+(int)point.z, Color.green);
        }
        
    }
}
