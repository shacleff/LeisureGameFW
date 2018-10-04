// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/DiffuseReflectionShader"
{
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
		SubShader{
				Pass{
			Tags{ "RenderType" = "Opaque" "LightMode" = "ForwardBase" }

			CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types

#pragma vertex vert
#pragma fragment frag 
#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform float4 _LightColor0;

	struct VertexOutput
	{
		float4 pos : SV_POSITION;
		float2 uv_MainTex:TEXCOORD0;
		float3 normal:TEXCOORD1;

	};

	VertexOutput vert(appdata_base input)
	{
		VertexOutput o;
		o.pos = UnityObjectToClipPos(input.vertex);
		o.uv_MainTex = input.texcoord.xy;
		o.normal = normalize(mul(float4(input.normal, 0), unity_WorldToObject));
		return o;
	}

	float4 frag(VertexOutput input) :COLOR
	{
		float3 normalDir = normalize(input.normal);
		float lightDir = normalize(_WorldSpaceLightPos0.xyz);
		float3 Kd = tex2D(_MainTex, input.uv_MainTex).xyz;
		float3 diffuseReflection = Kd*_LightColor0.rgb*max(0, dot(normalDir, lightDir));
		return float4(diffuseReflection, 2);
	}
		ENDCG
	}

	}
		FallBack "Diffuse"
}
