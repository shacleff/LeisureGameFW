// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_LightmapInd', a built-in variable
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D
// Upgrade NOTE: replaced tex2D unity_LightmapInd with UNITY_SAMPLE_TEX2D_SAMPLER

// Shader created with Shader Forge Beta 0.35 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.35;sub:START;pass:START;ps:flbk:VertexLit,lico:0,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:True,lprd:True,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:True,tesm:0,blpr:5,bsrc:3,bdst:7,culm:2,dpts:2,wrdp:True,ufog:True,aust:False,igpj:True,qofs:0,qpre:1,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.1280277,fgcg:0.1953466,fgcb:0.2352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:10,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:1,x:31045,y:32454|emission-2610-OUT,alpha-3690-OUT,clip-132-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:34270,y:31425,ptlb:MainTex,ptin:_MainTex,tex:66321cc856b03e245ac41ed8a53e0ecc,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Color,id:3,x:33488,y:31437,ptlb:ColorR,ptin:_ColorR,glob:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Multiply,id:4,x:33275,y:31293|A-2-RGB,B-5-OUT,C-3-RGB;n:type:ShaderForge.SFN_ValueProperty,id:5,x:33488,y:31360,ptlb:ColorPowerR,ptin:_ColorPowerR,glob:False,v1:2;n:type:ShaderForge.SFN_Clamp01,id:132,x:31974,y:32662|IN-2656-OUT;n:type:ShaderForge.SFN_Cubemap,id:1178,x:33995,y:32561,ptlb:CubeMap,ptin:_CubeMap,cube:6472564b09fac74498ba9b4fa1252e3a,pvfc:0|DIR-3150-XYZ;n:type:ShaderForge.SFN_Tex2d,id:1227,x:34106,y:31548,ntxv:0,isnm:False|TEX-2670-TEX;n:type:ShaderForge.SFN_Lerp,id:1230,x:32777,y:31478|A-2-RGB,B-4-OUT,T-1227-R;n:type:ShaderForge.SFN_Multiply,id:1372,x:33768,y:32654|A-1178-RGB,B-1373-RGB,C-3037-OUT;n:type:ShaderForge.SFN_Color,id:1373,x:33995,y:32716,ptlb:MainColor,ptin:_MainColor,glob:False,c1:0.5019608,c2:0.5019608,c3:0.5019608,c4:1;n:type:ShaderForge.SFN_Multiply,id:1560,x:31699,y:31940|A-1864-OUT,B-1372-OUT,C-3732-OUT;n:type:ShaderForge.SFN_Panner,id:1729,x:35057,y:32014,spu:1,spv:1|DIST-1765-OUT;n:type:ShaderForge.SFN_Time,id:1730,x:35662,y:31994;n:type:ShaderForge.SFN_Color,id:1760,x:34177,y:31765,ptlb:PannerColor,ptin:_PannerColor,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:1761,x:33435,y:31856|A-1760-RGB,B-2678-B,C-3432-OUT;n:type:ShaderForge.SFN_Multiply,id:1765,x:35355,y:32054|A-1730-TSL,B-2871-OUT;n:type:ShaderForge.SFN_Lerp,id:1864,x:31955,y:31553|A-1230-OUT,B-2756-OUT,T-1227-G;n:type:ShaderForge.SFN_Desaturate,id:2610,x:31338,y:32497|COL-3707-OUT,DES-2626-OUT;n:type:ShaderForge.SFN_Slider,id:2626,x:31591,y:32522,ptlb:Desaturate,ptin:_Desaturate,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:2656,x:32190,y:32636|A-2-A,B-3008-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:2670,x:34420,y:31714,ptlb:MaskMap,ptin:_MaskMap,glob:False;n:type:ShaderForge.SFN_Tex2d,id:2678,x:34177,y:31918,ntxv:0,isnm:False|UVIN-3488-OUT,TEX-2670-TEX;n:type:ShaderForge.SFN_Add,id:2756,x:32342,y:31788|A-1230-OUT,B-1761-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2871,x:35677,y:32159,ptlb:PanU,ptin:_PanU,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:2873,x:35637,y:32394,ptlb:PanV,ptin:_PanV,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:2879,x:35391,y:32329|A-1730-TSL,B-2873-OUT;n:type:ShaderForge.SFN_Append,id:2880,x:34670,y:32102|A-2917-OUT,B-3228-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2917,x:34892,y:32014,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1729-UVOUT;n:type:ShaderForge.SFN_Slider,id:3008,x:32439,y:32723,ptlb:ClipBias,ptin:_ClipBias,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ValueProperty,id:3037,x:33995,y:32878,ptlb:ColorPower,ptin:_ColorPower,glob:False,v1:2;n:type:ShaderForge.SFN_Transform,id:3150,x:34205,y:32561,tffrom:0,tfto:3|IN-3151-OUT;n:type:ShaderForge.SFN_NormalVector,id:3151,x:34450,y:32523,pt:False;n:type:ShaderForge.SFN_Transform,id:3183,x:35398,y:31789,tffrom:0,tfto:3;n:type:ShaderForge.SFN_ComponentMask,id:3184,x:35212,y:31789,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3183-XYZ;n:type:ShaderForge.SFN_Panner,id:3217,x:35057,y:32182,spu:1,spv:1|DIST-2879-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3228,x:34892,y:32182,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3217-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:3432,x:34232,y:32090,ptlb:PannerPower,ptin:_PannerPower,glob:False,v1:2;n:type:ShaderForge.SFN_TexCoord,id:3487,x:34875,y:31629,uv:0;n:type:ShaderForge.SFN_Add,id:3488,x:34403,y:31934|A-3495-OUT,B-2880-OUT;n:type:ShaderForge.SFN_Multiply,id:3489,x:34694,y:31744|A-3487-U,B-3490-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3490,x:34892,y:31860,ptlb:UTiling,ptin:_UTiling,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:3492,x:34892,y:31938,ptlb:VTiling,ptin:_VTiling,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:3494,x:34743,y:31921|A-3487-V,B-3492-OUT;n:type:ShaderForge.SFN_Append,id:3495,x:34603,y:31862|A-3489-OUT,B-3494-OUT;n:type:ShaderForge.SFN_Fresnel,id:3535,x:33646,y:32126;n:type:ShaderForge.SFN_Slider,id:3537,x:33485,y:32279,ptlb:FresnelPower,ptin:_FresnelPower,min:0,cur:2,max:5;n:type:ShaderForge.SFN_Power,id:3539,x:33205,y:32142|VAL-3535-OUT,EXP-3537-OUT;n:type:ShaderForge.SFN_Color,id:3541,x:32975,y:32187,ptlb:FresnelColor,ptin:_FresnelColor,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Vector1,id:3543,x:32975,y:32329,v1:2;n:type:ShaderForge.SFN_Multiply,id:3545,x:32504,y:32192|A-3539-OUT,B-3541-RGB,C-3543-OUT;n:type:ShaderForge.SFN_Clamp01,id:3690,x:32019,y:32503|IN-3692-OUT;n:type:ShaderForge.SFN_Subtract,id:3692,x:32194,y:32349|A-2-A,B-3694-OUT;n:type:ShaderForge.SFN_Slider,id:3694,x:32429,y:32533,ptlb:Alphabias,ptin:_Alphabias,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:3707,x:31703,y:32226|A-1560-OUT,B-3545-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3732,x:32078,y:32106,ptlb:Hit,ptin:_Hit,glob:False,v1:1;proporder:2626-3732-1373-3037-2-3694-3008-3-5-1178-1760-3432-2670-2871-2873-3490-3492-3537-3541;pass:END;sub:END;*/

Shader "TF/Role" {
    Properties {
        _Desaturate ("Desaturate", Range(0, 1)) = 0
        _Hit ("Hit", Float ) = 1
        _MainColor ("MainColor", Color) = (0.5019608,0.5019608,0.5019608,1)
        _ColorPower ("ColorPower", Float ) = 2
        _MainTex ("MainTex", 2D) = "gray" {}
        _Alphabias ("Alphabias", Range(0, 1)) = 0
        _ClipBias ("ClipBias", Range(0, 1)) = 0
        _ColorR ("ColorR", Color) = (0.5019608,0.5019608,0.5019608,1)
        _ColorPowerR ("ColorPowerR", Float ) = 2
        _CubeMap ("CubeMap", Cube) = "_Skybox" {}
        _PannerColor ("PannerColor", Color) = (0,0,0,1)
        _PannerPower ("PannerPower", Float ) = 2
        _MaskMap ("MaskMap", 2D) = "black" {}
        _PanU ("PanU", Float ) = 1
        _PanV ("PanV", Float ) = 1
        _UTiling ("UTiling", Float ) = 1
        _VTiling ("VTiling", Float ) = 1
        _FresnelPower ("FresnelPower", Range(0, 5)) = 2
        _FresnelColor ("FresnelColor", Color) = (0,0,0,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
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
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), unity_WorldToObject).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                #ifndef LIGHTMAP_OFF
                    o.uvLM = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
                #endif
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float2 node_3772 = i.uv0;
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3772.rg, _MainTex));
                clip(saturate((node_2.a-_ClipBias)) - 0.5);
                #ifndef LIGHTMAP_OFF
                    float4 lmtex = UNITY_SAMPLE_TEX2D(unity_Lightmap,i.uvLM);
                    #ifndef DIRLIGHTMAP_OFF
                        float3 lightmap = DecodeLightmap(lmtex);
                        float3 scalePerBasisVector = DecodeLightmap(UNITY_SAMPLE_TEX2D_SAMPLER(unity_LightmapInd,unity_Lightmap,i.uvLM));
                        UNITY_DIRBASIS
                        half3 normalInRnmBasis = saturate (mul (unity_DirBasis, float3(0,0,1)));
                        lightmap *= dot (normalInRnmBasis, scalePerBasisVector);
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
                float2 node_3488 = (float2((node_3487.r*_UTiling),(node_3487.g*_VTiling))+float2((node_3772.rg+(node_1730.r*_PanU)*float2(1,1)).r,(node_3772.rg+(node_1730.r*_PanV)*float2(1,1)).g));
                float3 emissive = lerp(((lerp(node_1230,(node_1230+(_PannerColor.rgb*tex2D(_MaskMap,TRANSFORM_TEX(node_3488, _MaskMap)).b*_PannerPower)),node_1227.g)*(texCUBE(_CubeMap,mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb).rgb*_MainColor.rgb*_ColorPower)*_Hit)+(pow((1.0-max(0,dot(normalDirection, viewDirection))),_FresnelPower)*_FresnelColor.rgb*2.0)),dot(((lerp(node_1230,(node_1230+(_PannerColor.rgb*tex2D(_MaskMap,TRANSFORM_TEX(node_3488, _MaskMap)).b*_PannerPower)),node_1227.g)*(texCUBE(_CubeMap,mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb).rgb*_MainColor.rgb*_ColorPower)*_Hit)+(pow((1.0-max(0,dot(normalDirection, viewDirection))),_FresnelPower)*_FresnelColor.rgb*2.0)),float3(0.3,0.59,0.11)),_Desaturate);
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,saturate((node_2.a-_Alphabias)));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            Cull Off
            
            Fog {Mode Off}
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
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                float2 node_3773 = i.uv0;
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3773.rg, _MainTex));
                clip(saturate((node_2.a-_ClipBias)) - 0.5);
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            Fog {Mode Off}
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
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                float2 node_3774 = i.uv0;
                float4 node_2 = tex2D(_MainTex,TRANSFORM_TEX(node_3774.rg, _MainTex));
                clip(saturate((node_2.a-_ClipBias)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "VertexLit"
}
