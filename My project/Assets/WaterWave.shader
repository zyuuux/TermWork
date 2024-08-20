
Shader "Custom/WaterWave Effect" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
 
	CGINCLUDE
	#include "UnityCG.cginc"
	uniform sampler2D _MainTex;
	float4 _MainTex_TexelSize;
	uniform float _distanceFactor;
	uniform float _timeFactor;
	uniform float _totalFactor;
	uniform float _waveWidth;
	uniform float _curWaveDis;
	uniform float4 _startPos;
 
	fixed4 frag(v2f_img i) : SV_Target
	{
			//DX���������귴������
		#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				_startPos.y = 1 - _startPos.y;
		#endif
			//����uv���м�������(������������������������)
		float2 dv = _startPos.xy - i.uv;
			//������Ļ����Ƚ�������
		dv = dv * float2(_ScreenParams.x / _ScreenParams.y, 1);
			//�������ص���е�ľ���
		float dis = sqrt(dv.x * dv.x + dv.y * dv.y);
			//��sin������������ε�ƫ��ֵfactor
			//dis�����ﶼ��С��1�ģ�����������Ҫ����һ���Ƚϴ����������60���������ж�����岨��
			//sin�����ǣ�-1��1����ֵ������ϣ��ƫ��ֵ��С����������������С100������˵�˷��ȽϿ�,so...
		float sinFactor = sin(dis * _distanceFactor + _Time.y * _timeFactor) * _totalFactor * 0.01;
			//���뵱ǰ�����˶���ľ��룬���С��waveWidth�����Ա����������Ѿ����˲��Ʒ�Χ��factorͨ��clamp����Ϊ0
		float discardFactor = clamp(_waveWidth - abs(_curWaveDis - dis), 0, 1) / _waveWidth;
			//��һ��
		float2 dv1 = normalize(dv);
			//����ÿ������uv��ƫ��ֵ
		float2 offset = dv1 * sinFactor * discardFactor;
			//���ز���ʱƫ��offset
		float2 uv = offset + i.uv;
		return tex2D(_MainTex, uv);
	}
 
	ENDCG
 
	SubShader
	{
		Pass
		{
			ZTest Always
			Cull Off
			ZWrite Off

		Fog { Mode off }
 
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest 
		ENDCG
		}
	}
	Fallback off
}

