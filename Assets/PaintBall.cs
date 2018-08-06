using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour {
    public Rigidbody rb;
    public SphereCollider sc;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {


        sc.enabled = false;

        for (int i = 0; i < 25; i++)
        {
            var dir = new Vector3((float)(PaintGun.r.NextDouble() * 2.0 - 1.0), (float)(PaintGun.r.NextDouble() * 2.0 - 1.0), (float)(PaintGun.r.NextDouble() * 2.0 - 1.0));
            var dir2 = collision.contacts[0].point-transform.position;

            PaintRay(dir * 0.4f + dir2);
            PaintRay(dir * 0.2f + dir2);
        }

        PaintGun.tex.Apply();

        Destroy(gameObject);
    }

    public void PaintRay(Vector3 dir)
    {
        //if (PaintGun.r.Next(6) < 2) return; // Used to add more randomness

        RaycastHit rh;
        Physics.Raycast(transform.position, dir, out rh, 0.7f);

        if (rh.transform != null)
        {
            int x = (int)(rh.textureCoord.x * PaintGun.tex.width);
            int y = (int)(rh.textureCoord.y * PaintGun.tex.height);

            RandomBrush(x, y, 3, 4);

        }
    }

    public void RandomBrush(int x, int y, int taps, int radius)
    {
        for (int i = 0; i < (taps + 1); i++)
        {
            float rx = (float)PaintGun.r.NextDouble() * (float)radius;

            Vector3 point = new Vector3(rx, 0, rx);
            int ry = PaintGun.r.Next(360);
            point = Quaternion.AngleAxis(ry, Vector3.up) * point;


            PaintGun.tex.SetPixel(x + (int)point.x, y + (int)point.z, Color.red);
        }

    }
}
