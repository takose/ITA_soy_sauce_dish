using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]
public class CreateTriangle : MonoBehaviour
{
	// 変更箇所 : Materialを保持するようにする
	[SerializeField]
	private Material _mat;
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
		Application.ExternalCall("UnityAwake");
	}

	public void make_stl(string polygon_str){
		Debug.Log (polygon_str);
		var mesh = new Mesh ();		
		string[] word = polygon_str.Split(',');
		Vector3[] polygons = new Vector3[(word.Length-1)/3];
		int[] polygons_zyunban = new int[(word.Length-1)/3];
		int loop_num = (word.Length - 1) / 3;
		for (int i = 0; i<loop_num; i++) {
			polygons[i] = new Vector3 (float.Parse(word[i+(2*i)]),float.Parse(word[i+1+(2*i)]),float.Parse(word[i+2+(2*i)]));
			polygons_zyunban[i] = i;
		}
			
		mesh.vertices = polygons;
		mesh.triangles = polygons_zyunban;
		mesh.RecalculateNormals ();
		var filter = GetComponent<MeshFilter> ();
		filter.sharedMesh = mesh;

		// 変更箇所 : MeshRendererからMaterialにアクセスし、Materialをセットするようにする
		var renderer = GetComponent<MeshRenderer> ();
		renderer.material = _mat;


	}
}