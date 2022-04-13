Shader "Custom/stencil"
{
    Properties{

    }

    SubShader{
        Tags {"Queue" = "Geometry-1"}
        ColorMask 0

        ZWrite off

        Stencil {
        Ref 1
        Comp always
        Pass replace
}

        CGPROGRAM

        #pragma surface surf Lambert
        struct Input {
        float3 worldPos; //because empty input causes error
        };
        
        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = fixed4(1, 1, 1, 1);
        }
        ENDCG
    }
        Fallback "Diffuse"
}
