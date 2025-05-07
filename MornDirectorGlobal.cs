using MornEditor;
using MornGlobal;
using MornSound;
using MornTransition;
using UnityEngine;

namespace MornDirector
{
    [CreateAssetMenu(fileName = nameof(MornDirectorGlobal), menuName = nameof(MornDirectorGlobal))]
    public sealed class MornDirectorGlobal : MornGlobalBase<MornDirectorGlobal>
    {
        protected override string ModuleName => nameof(MornDirectorGlobal);
        [Header("トランジション")]
        [Label("トランジションタイプ")] public MornTransitionType TransitionType;
        [Header("音量")]
        [Label("音量フェードタイプ")] public MornSoundVolumeType VolumeFadeType;
        [Label("音量フェードイン(s)")] public float VolumeFadeInDuration = 0.5f;
        [Label("音量フェードイン(s)")] public float VolumeFadeOutDuration = 0.5f;
    }
}