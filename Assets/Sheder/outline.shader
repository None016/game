Shader "Custom/outline"
{
     Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,0,0,1)
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.01
        _EnableOutline ("Enable Outline", Float) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _OutlineColor;
            float _OutlineWidth;
            float _EnableOutline;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;

                if (_EnableOutline > 0.5)
                {
                    // ѕровер€ем соседние пиксели на прозрачность
                    float alpha = tex2D(_MainTex, i.uv).a;
                    float alphaUp = tex2D(_MainTex, i.uv + float2(0, _OutlineWidth)).a;
                    float alphaDown = tex2D(_MainTex, i.uv - float2(0, _OutlineWidth)).a;
                    float alphaLeft = tex2D(_MainTex, i.uv + float2(_OutlineWidth, 0)).a;
                    float alphaRight = tex2D(_MainTex, i.uv - float2(_OutlineWidth, 0)).a;

                    if (alpha < 0.5 && (alphaUp > 0.5 || alphaDown > 0.5 || alphaLeft > 0.5 || alphaRight > 0.5))
                    {
                        col = _OutlineColor;
                    }
                }

                return col;
            }
            ENDCG
        }
    }
}
