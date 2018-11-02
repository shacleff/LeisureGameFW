
Shader "TF/BasicRole" {
	Properties{
		_Desaturate("Desaturate", Range(0, 1)) = 0
		_Hit("Hit", Float) = 1
		_MainColor("MainColor", Color) = (0.5019608,0.5019608,0.5019608,1)
		_ColorPower("ColorPower", Float) = 2
		_MainTex("MainTex", 2D) = "gray" {}
	_Alphabias("Alphabias", Range(0, 1)) = 0
		_ClipBias("ClipBias", Range(0, 1)) = 0
		_ColorR("ColorR", Color) = (0.5019608,0.5019608,0.5019608,1)
		_ColorPowerR("ColorPowerR", Float) = 2
		_CubeMap("CubeMap", Cube) = "_Skybox" {}
	_PannerColor("PannerColor", Color) = (0,0,0,1)
		_PannerPower("PannerPower", Float) = 2
		_MaskMap("MaskMap", 2D) = "black" {}
	_PanU("PanU", Float) = 1
		_PanV("PanV", Float) = 1
		_UTiling("UTiling", Float) = 1
		_VTiling("VTiling", Float) = 1
		_FresnelPower("FresnelPower", Range(0, 5)) = 2
		_FresnelColor("FresnelColor", Color) = (0,0,0,1)
		[HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}
		SubShader{
		Tags{
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
	}
		Pass{
		Name "ForwardBase"
		Tags{
		"LightMode" = "ForwardBase"
	}
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off


		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#define UNITY_PASS_FORWARDBASE
#include "UnityCG.cginc"
#include "Lighting.cginc"
#pragma multi_compile_fwdbase
#pragma exclude_renderers d3d11 xbox360 ps3 flash d3d11_9x 
#pragma target 2.0
		uniform float4 _TimeEditor;
#ifndef LIGHTMAP_OFF
	// float4 unity_LightmapST;
	// sampler2D unity_Lightmap;
#ifndef DIRLIGHTMAP_OFF
	// sampler2D unity_LightmapInd;
#endif
#endif
	uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
	uniform float4 _ColorR;
	uniform float _ColorPowerR;
	uniform samplerCUBE _CubeMap;
	uniform float4 _MainColor;
	uniform float4 _PannerColor;
	uniform float _Desaturate;
	uniform sampler2D _MaskMap; uniform float4 _MaskMap_ST;
	uniform float _PanU;
	uniform float _PanV;
	uniform float _ClipBias;
	uniform float _ColorPower;
	uniform float _PannerPower;
	uniform float _UTiling;
	uniform float _VTiling;
	uniform float _FresnelPower;
	uniform float4 _FresnelColor;
	uniform float _Alphabias;
	uniform float _Hit;
	struct VertexInput {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float4 tangent : TANGENT;
		float2 texcoord0 : TEXCOORD0;
		float2 texcoord1 : TEXCOORD1;
	};
	struct VertexOutput {
		float4 pos : SV_POSITION;
		float2 uv0 : TEXCOORD0;
		float4 posWorld : TEXCOORD1;
		float3 normalDir : TEXCOORD2;
		float3 tangentDir : TEXCOORD3;
		float3 binormalDir : TEXCOORD4;
#ifndef LIGHTMAP_OFF
		float2 uvLM : TEXCOORD5;
#endif
	};
	VertexOutput vert(VertexInput v) {
		VertexOutput o;
		o.uv0 = v.texcoord0;
		o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
		o.tangentDir = normalize(mul(unity_ObjectToWorld, float4(v.tangent.xyz, 0.0)).xyz);
		o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
		o.posWorld = mul(unity_ObjectToWorld, v.vertex);
		o.pos = UnityObjectToClipPos(v.vertex);
#ifndef LIGHTMAP_OFF
		o.uvLM = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
#endif
		return o;
	}
	fixed4 frag(VertexOutput i) : COLOR{
		i.normalDir = normalize(i.normalDir);
	float3x3 tangentTransform = float3x3(i.tangentDir, i.binormalDir, i.normalDir);
	float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
	/////// Normals:
	float3 normalDirection = i.normalDir;

	float nSign = sign(dot(viewDirection, i.normalDir)); // Reverse normal if this is a backface
	i.normalDir *= nSign;
	normalDirection *= nSign;

	float2 node_3772 = i.uv0;
	float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3772.rg, _MainTex));
	clip(saturate((node_2.a - _ClipBias)) - 0.5);
#ifndef LIGHTMAP_OFF
	float4 lmtex = UNITY_SAMPLE_TEX2D(unity_Lightmap,i.uvLM);
#ifndef DIRLIGHTMAP_OFF
	float3 lightmap = DecodeLightmap(lmtex);
	float3 scalePerBasisVector = DecodeLightmap(UNITY_SAMPLE_TEX2D_SAMPLER(unity_LightmapInd,unity_Lightmap,i.uvLM));
	UNITY_DIRBASIS
		half3 normalInRnmBasis = saturate(mul(unity_DirBasis, float3(0,0,1)));
		lightmap *= dot(normalInRnmBasis, scalePerBasisVector);
#else
	float3 lightmap = DecodeLightmap(lmtex);
#endif
#endif
	////// Lighting:
	////// Emissive:
	float4 node_1227 = tex2D(_MaskMap,TRANSFORM_TEX(node_3772.rg, _MaskMap));
	float3 node_1230 = lerp(node_2.rgb,(node_2.rgb*_ColorPowerR*_ColorR.rgb),node_1227.r);
	float2 node_3487 = i.uv0;
	float4 node_1730 = _Time + _TimeEditor;
	float2 node_3488 = (float2((node_3487.r*_UTiling),(node_3487.g*_VTiling)) + float2((node_3772.rg + (node_1730.r*_PanU)*float2(1,1)).r,(node_3772.rg + (node_1730.r*_PanV)*float2(1,1)).g));
	float3 emissive = lerp(((lerp(node_1230,(node_1230 + (_PannerColor.rgb*tex2D(_MaskMap,TRANSFORM_TEX(node_3488, _MaskMap)).b*_PannerPower)),node_1227.g)*(texCUBE(_CubeMap,mul(UNITY_MATRIX_V, float4(i.normalDir,0)).xyz.rgb).rgb*_MainColor.rgb*_ColorPower)*_Hit) + (pow((1.0 - max(0,dot(normalDirection, viewDirection))),_FresnelPower)*_FresnelColor.rgb*2.0)),dot(((lerp(node_1230,(node_1230 + (_PannerColor.rgb*tex2D(_MaskMap,TRANSFORM_TEX(node_3488, _MaskMap)).b*_PannerPower)),node_1227.g)*(texCUBE(_CubeMap,mul(UNITY_MATRIX_V, float4(i.normalDir,0)).xyz.rgb).rgb*_MainColor.rgb*_ColorPower)*_Hit) + (pow((1.0 - max(0,dot(normalDirection, viewDirection))),_FresnelPower)*_FresnelColor.rgb*2.0)),float3(0.3,0.59,0.11)),_Desaturate);
	float3 finalColor = emissive;
	/// Final Color:
	return fixed4(finalColor,saturate((node_2.a - _Alphabias)));
	}
		ENDCG
	}
		Pass{
		Name "ShadowCollector"
		Tags{
		"LightMode" = "ShadowCollector"
	}
		Cull Off

		Fog{ Mode Off }
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#define UNITY_PASS_SHADOWCOLLECTOR
#define SHADOW_COLLECTOR_PASS
#include "UnityCG.cginc"
#include "Lighting.cginc"
#pragma fragmentoption ARB_precision_hint_fastest
#pragma multi_compile_shadowcollector
#pragma exclude_renderers d3d11 xbox360 ps3 flash d3d11_9x 
#pragma target 2.0
#ifndef LIGHTMAP_OFF
		// float4 unity_LightmapST;
		// sampler2D unity_Lightmap;
#ifndef DIRLIGHTMAP_OFF
		// sampler2D unity_LightmapInd;
#endif
#endif
		uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
	uniform float _ClipBias;
	struct VertexInput {
		float4 vertex : POSITION;
		float2 texcoord0 : TEXCOORD0;
	};
	struct VertexOutput {
		V2F_SHADOW_COLLECTOR;
		float2 uv0 : TEXCOORD5;
	};
	VertexOutput vert(VertexInput v) {
		VertexOutput o;
		o.uv0 = v.texcoord0;
		o.pos = UnityObjectToClipPos(v.vertex);
		TRANSFER_SHADOW_COLLECTOR(o)
			return o;
	}
	fixed4 frag(VertexOutput i) : COLOR{
		float2 node_3773 = i.uv0;
		float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3773.rg, _MainTex));
		clip(saturate((node_2.a - _ClipBias)) - 0.5);
		SHADOW_COLLECTOR_FRAGMENT(i)
	}
		ENDCG
	}
		Pass{
			Name "ShadowCaster"
			Tags{
			"LightMode" = "ShadowCaster"
		}
			Cull Off
			Offset 1, 1

			Fog{ Mode Off }
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#define UNITY_PASS_SHADOWCASTER
#include "UnityCG.cginc"
#include "Lighting.cginc"
#pragma fragmentoption ARB_precision_hint_fastest
#pragma multi_compile_shadowcaster
#pragma exclude_renderers d3d11 xbox360 ps3 flash d3d11_9x 
#pragma target 2.0
#ifndef LIGHTMAP_OFF
			// float4 unity_LightmapST;
			// sampler2D unity_Lightmap;
#ifndef DIRLIGHTMAP_OFF
			// sampler2D unity_LightmapInd;
#endif
#endif
			uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
		uniform float _ClipBias;
		struct VertexInput {
			float4 vertex : POSITION;
			float2 texcoord0 : TEXCOORD0;
		};
		struct VertexOutput {
			V2F_SHADOW_CASTER;
			float2 uv0 : TEXCOORD1;
		};
		VertexOutput vert(VertexInput v) {
			VertexOutput o;
			o.uv0 = v.texcoord0;
			o.pos = UnityObjectToClipPos(v.vertex);
			TRANSFER_SHADOW_CASTER(o)
				return o;
		}
		fixed4 frag(VertexOutput i) : COLOR{
			float2 node_3774 = i.uv0;
			float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3774.rg, _MainTex));
			clip(saturate((node_2.a - _ClipBias)) - 0.5);
			SHADOW_CASTER_FRAGMENT(i)
		}
			ENDCG
		}
	}
		FallBack "VertexLit"
}
