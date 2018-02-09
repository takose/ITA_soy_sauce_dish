using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]
public class CreateTriangle : MonoBehaviour
{
	// 変更箇所 : Materialを保持するようにする
	[SerializeField]
	private Material _mat;
	List<Vector3> polygonslist = new List<Vector3>();
	private int count = 0;
	Vector3 polygon = new Vector3(0,0,0);
/*
	private void Start ()
	{
		var mesh = new Mesh ();
		mesh.vertices = new Vector3[] {
			new Vector3 (0, 1f),
			new Vector3 (1f, -1f),
			new Vector3 (-1f, -1f),
			new Vector3 (0, -2f),
			new Vector3 (-2f, 2f),
			new Vector3 (2f, 2f),
		};
		mesh.triangles = new int[] {
			0, 1, 2,3,4,5
		};
		mesh.RecalculateNormals ();
		var filter = GetComponent<MeshFilter> ();
		filter.sharedMesh = mesh;

		// 変更箇所 : MeshRendererからMaterialにアクセスし、Materialをセットするようにする
		var renderer = GetComponent<MeshRenderer> ();
		renderer.material = _mat;
	}
*/

	public void Awake(){
		//gameInstance.SendMessage('make_stl', 'make_stl', '30,30,2.01,30,-30,2.01,-30,-30,2.01,');
		Application.ExternalCall("UnityAwake");
		/*

		cube
		0,0,0,0,0,20,0,20,20,0,20,0,20,0,0,20,20,0,20,20,20,20,0,20,0,0,0,20,0,0,20,0,20,0,0,20,0,20,0,0,20,20,20,20,20,20,20,0,0,0,0,0,20,0,20,20,0,20,0,0,0,0,20,20,0,20,20,20,20,0,20,20,
		(0,1,2)と(0,2,3)
		*/

		/*
		makepolygons ();
		makepolygons ();
		makepolygons ();
		makepolygons ();
		*/
	}

	public void pushpolygons(float num){
		count++;		
		if (count == 1) {
			polygon = new Vector3 (num,polygon.y,polygon.z);
		} else if (count == 2) {
			polygon = new Vector3 (polygon.x,num,polygon.z);
		} else if (count == 3) {
			polygon = new Vector3 (polygon.x,polygon.y,num);			
			polygonslist.Add (polygon);			
			count=0;
		}
	}
	/*
	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			float[] polygons_test = {
				0,
				0,
				0,
				0,
				0,
				20,
				0,
				20,
				20,
				0,
				20,
				0,
				20,
				0,
				0,
				20,
				20,
				0,
				20,
				20,
				20,
				20,
				0,
				20,
				0,
				0,
				0,
				20,
				0,
				0,
				20,
				0,
				20,
				0,
				0,
				20,
				0,
				20,
				0,
				0,
				20,
				20,
				20,
				20,
				20,
				20,
				20,
				0,
				0,
				0,
				0,
				0,
				20,
				0,
				20,
				20,
				0,
				20,
				0,
				0,
				0,
				0,
				20,
				20,
				0,
				20,
				20,
				20,
				20,
				0,
				20,
				20
			};
			for (int i = 0; i < polygons_test.Length; i++) {
				pushpolygons (polygons_test [i]);			
			}
			makepolygons ();
		}
	}
	*/

	public void makepolygons(){
		var filter = GetComponent<MeshFilter> ();
		//filter.sharedMesh.Clear();
		//filter.mesh.Clear ();
		List<Vector3> polygonslist_result = new List<Vector3>();
		var mesh = new Mesh ();		
		int loop_num = polygonslist.Count;

		for (int i = 0; i < loop_num; i+=4) {
			polygonslist_result.Add (polygonslist [i]);
			polygonslist_result.Add (polygonslist [i+1]);
			polygonslist_result.Add (polygonslist [i+2]);

			polygonslist_result.Add (polygonslist [i]);
			polygonslist_result.Add (polygonslist [i+2]);
			polygonslist_result.Add (polygonslist [i+3]);
		}

		loop_num = polygonslist_result.Count;
		int [] polygons_zyunban = new int[loop_num];

		for (int i = 0; i<loop_num; i++) {
			polygons_zyunban[i] = i;
		}
			
		mesh.vertices = polygonslist_result.ToArray();
		mesh.triangles = polygons_zyunban;
		mesh.RecalculateNormals ();
		filter.sharedMesh = mesh;		

		// 変更箇所 : MeshRendererからMaterialにアクセスし、Materialをセットするようにする
		var renderer = GetComponent<MeshRenderer> ();
		renderer.material = _mat;

		polygonslist = new List<Vector3>();
		polygonslist_result = new List<Vector3>();
		polygons_zyunban = null;
		count = 0;
	}
}