#version 450
#extension GL_GOOGLE_include_directive : enable

#include "Common.h"
#include "Lighting.h"
#include "Cloud.h"
#include "Mesh.h"

layout(set = 0, binding = 0) uniform GlobalConstantsShared
{
    GlobalConstantsSharedType _GlobalConstantsShared;
};

layout(set = 0, binding = 1) uniform GlobalConstantsVS
{
    GlobalConstantsVSType _GlobalConstantsVS;
};

layout(set = 0, binding = 2) uniform GlobalLightingConstantsVS
{
    GlobalLightingConstantsVSType _GlobalLightingConstantsVS;
};

layout(set = 0, binding = 3) uniform MeshConstants
{
    MeshConstantsType _MeshConstants;
};

layout(set = 0, binding = 4) uniform RenderItemConstantsVS
{
    RenderItemConstantsVSType _RenderItemConstantsVS;
};

layout(set = 0, binding = 5) readonly buffer SkinningBuffer
{
    mat4 _SkinningBuffer[];
};

MESH_VERTEX_INPUTS

layout(location = 0) out vec3 out_WorldPosition;
layout(location = 1) out vec3 out_WorldNormal;
layout(location = 2) out vec2 out_UV0;
layout(location = 3) out vec2 out_UV1;
layout(location = 4) out vec2 out_CloudUV;
layout(location = 5) out float out_ViewSpaceDepth;

void main()
{
    vec3 modifiedPosition = in_Position;
    vec3 modifiedNormal = in_Normal;

    if (_MeshConstants.SkinningEnabled)
    {
        GetSkinnedVertexData(
            in_Position, 
            in_Normal,
            _SkinningBuffer[in_BoneIndex],
            modifiedPosition,
            modifiedNormal);
    }

    VSSkinnedInstanced(
        modifiedPosition,
        modifiedNormal,
        gl_Position,
        out_WorldPosition,
        out_WorldNormal,
        out_CloudUV,
        _RenderItemConstantsVS.World,
        _GlobalConstantsVS.ViewProjection,
        _GlobalLightingConstantsVS.CloudShadowMatrix,
        _GlobalConstantsShared.TimeInSeconds);

    out_UV0 = in_UV0;
    out_UV1 = in_UV1;

    out_ViewSpaceDepth = gl_Position.z;
}