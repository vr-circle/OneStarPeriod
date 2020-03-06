// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Shihouette" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_OutlineColor("Outline Color",Color) = (1,1,1,1)
		_OutlineWidth("outline width",Range(0,0.5)) = 0.01

	}

		SubShader{
		Pass{
		Tags{ "Queue" = "Geometry-1" "RenderType" = "Opaque" }
		ZTest Off
		ZWrite Off
		ColorMask 0
		Cull Off

		Stencil{
		Ref 2
		CompFront always
		CompBack always
		PassFront replace
		PassBack replace
	}

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		uniform float _OutlineWidth;

	float4 vert(float4 pos : POSITION,float3 normal : NORMAL) : SV_POSITION{
		float4 wPos = UnityObjectToClipPos(pos);
		wPos += float4(UnityObjectToWorldNormal(normal) * _OutlineWidth,0);
		return wPos;
	}

		float4 frag() : SV_TARGET{
		return float4(1,1,1,1);
	}
		ENDCG
	}

		Pass{
		Tags{ "Queue" = "Geometry" "RenderType" = "Opaque" }
		ZTest LEqual
		ZWrite On
		Stencil{
		Ref 3
		CompFront always
		CompBack always
		PassFront replace
		PassBack replace
		FailFront replace
		FailBack replace
		//ZFailBack replace
		//ZFailFront replace
	}
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
		uniform float4 _Color;

	float4 vert(float4 pos : POSITION) : SV_POSITION{
		return UnityObjectToClipPos(pos);
	}

		float4 frag() : SV_TARGET{
		return _Color;
	}
		ENDCG
	}

		Pass{
		Tags{ "Queue" = "Ovarlay" "RenderType" = "Opaque" }
		ZTest Off
		ZWrite Off

		Stencil{
		Ref 2
		Comp Equal
	}
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
		uniform float4 _OutlineColor;
	uniform float _OutlineWidth;

	float4 vert(float4 pos : POSITION,float3 normal : NORMAL) : SV_POSITION{
		float4 wPos = UnityObjectToClipPos(pos);
		wPos += float4(UnityObjectToWorldNormal(normal) * _OutlineWidth,0);
		return wPos;
	}

		float4 frag() : SV_TARGET{
		return _OutlineColor;
	}
		ENDCG
	}
	}
}