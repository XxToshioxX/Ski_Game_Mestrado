using UnityEngine;
using System.Collections;


[AddComponentMenu("Camera-Control/zSight")]

public class zSight : MonoBehaviour {

	//Sensics Code
	public float qwo;
	public float qxo;
	public float qyo;
	public float qzo;
	public int qw;
	public int qx;
	public int qy;
	public int qz;
	public int qwd;
	public int qxd;
	public int qyd;
	public int qzd;
	public float qwf;
	public float qxf;
	public float qyf;
	public float qzf;
	public int qww;
	public int qxx;
	public int qyy;
	public int qzz;
	public float headYaw;
	public float headAttitude;
	public float headBank;
	public float a;
	public float b;
	public float c;
	public float d;
	
	public float norm;
	

	void Update ()
	{

				//Sensics Code
				qwo = Input.GetAxis("Quaternion W");
				qxo = Input.GetAxis("Quaternion X");
				qyo = -Input.GetAxis("Quaternion Y");
				qzo = Input.GetAxis("Quaternion Z");
				
				qwo = (qwo + 1) * 32767;
				qxo = (qxo + 1) * 32767;
				qyo = (qyo + 1) * 32767;
				qzo = (qzo + 1) * 32767;
				
				qw = (int)qwo;
				qx = (int)qxo;
				qy = (int)qyo;
				qz = (int)qzo;
				
				if (qw > 32768) {
					qw = qw ^ 65535;
					qww = qw;
					if (qww < 32767 | qww > 32767){
						qww = qww + 1;
					}
					qww = -qww;
					qw = qww;
				}
				if (qx > 32768) {
					qx = qx ^ 65535;
					qxx = qx;
					if (qxx < 32767 | qxx > 32767){
						qxx = qxx + 1;
					}
					qxx = -qxx;
					qx = qxx;
				}
				if (qy > 32768) {
					qy = qy ^ 65535;
					qyy = qy;
					if (qyy < 32767 | qyy > 32767){
						qyy = qyy + 1;
					}
					qyy = -qyy;
					qy = qyy;
				}
				if (qz > 32768) {
					qz = qz ^ 65535;
					qzz = qz;
					if (qzz < 32767 | qzz > 32767){
						qzz = qzz + 1;
					}
					qzz = -qzz;
					qz = qzz;
				}
				
				qwd=qw;
				qyd=qy;
				qxd=qx;
				qzd=qz;
				
				norm = Mathf.Sqrt((float)qx*(float)qx+(float)qy*(float)qy+(float)qz*(float)qz+(float)qw*(float)qw);
				qwf=(float)qw/norm;
				qxf=(float)qx/norm;
				qyf=(float)qy/norm;
				qzf=(float)qz/norm;
				
				/*qwf = b;
				qxf = c;
				qyf = -d;
				qzf = a;*/
				headYaw = -Mathf.Atan2(2f*qxf*qyf + 2f*qwf*qzf, qzf*qzf - qwf*qwf - qxf*qxf + qyf*qyf);
				headAttitude=Mathf.Asin((2f * qwf * qyf) - (2f * qxf * qzf));
				headBank = Mathf.Atan2(2f*qwf*qxf + 2f*qyf*qzf, qzf*qzf + qwf*qwf - qxf*qxf - qyf*qyf);
				

				//End Sensics code.


				transform.localEulerAngles = new Vector3(-headAttitude/Mathf.PI*180f,  headBank/Mathf.PI*180f, -headYaw/Mathf.PI*180f);            
			
			
	}
	
}