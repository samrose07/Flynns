Shader "Custom/DepthMask"
{
    SubShader{
        //render after refular geo, but before masked geo and transparent things

        Tags {"Queue" = "Geometry-1"}

        Stencil {
        Ref 2
        Comp always
        Pass Replace
}

        //don't draw RGBA channels just the depth buffer
        ColorMask 0
        ZWrite On

        //do nothing specific in pass
        Pass{}
    }
}
