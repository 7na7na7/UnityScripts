using UnityEngine;

using UnityEditor;



public class TexturePostProcessor : AssetPostprocessor

{

	void OnPostprocessTexture(Texture2D texture)

	{

		TextureImporter importer = assetImporter as TextureImporter;

		importer.textureType = TextureImporterType.Default;   // 기본 타입을 Advanced로..

		importer.anisoLevel = 1;

		importer.filterMode = FilterMode.Point;

		importer.alphaSource=TextureImporterAlphaSource.FromInput;
		importer.textureCompression=TextureImporterCompression.Uncompressed;

// 필요한 설정값을 이곳에 넣어주시면 됩니다.



		Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Texture2D));

		if (asset)

		{

			EditorUtility.SetDirty(asset);

		}

		else

		{

			texture.anisoLevel = 1;

			texture.filterMode = FilterMode.Bilinear;          

		} 

	}

}