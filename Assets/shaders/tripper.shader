Shader "tripper" 
{
	Properties 
	{
		_MainTex("albedo", 2D) = "white" {}
		_DiffuseMap ("Diffuse Map ", 2D)  = "white" {}
		_TextureScale ("Texture Scale",float) = 1
		_TriplanarBlendSharpness ("Blend Sharpness",float) = 1
	}
	SubShader 
	{
		//#include "UnityStandardCore.cginc"

		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float _TextureScale;
		float _TriplanarBlendSharpness;

		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
		}; 

		void surf (Input IN, inout SurfaceOutput o) 
		{
			half2 yUV = IN.worldPos.xz / _TextureScale;
			half2 xUV = IN.worldPos.zy / _TextureScale;
			half2 zUV = IN.worldPos.xy / _TextureScale;
			half3 yDiff = tex2D (_MainTex, yUV);
			half3 xDiff = tex2D (_MainTex, xUV);
			half3 zDiff = tex2D (_MainTex, zUV);
			half3 blendWeights = pow (abs(IN.worldNormal), _TriplanarBlendSharpness);
			blendWeights = blendWeights / (blendWeights.x + blendWeights.y + blendWeights.z);
			o.Albedo = xDiff * blendWeights.x + yDiff * blendWeights.y + zDiff * blendWeights.z;
		}
		ENDCG
	}
}