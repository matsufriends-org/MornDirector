using Arbor;
using Cysharp.Threading.Tasks;
using MornSound;
using MornTransition;
using MornUtil;
using UnityEngine;
using VContainer;

namespace MornDirector
{
    public class EnterSceneState : StateBehaviour
    {
        [Inject] private MornTransitionCtrl _transitionCtrl;
        [Inject] private MornSoundVolumeCore _volumeCore;
        [SerializeField] private bool _isExecuteAsIsolated;
        [SerializeField] private StateLink _nextState;

        public override async void OnStateBegin()
        {
            var ct = _isExecuteAsIsolated ? MornApp.QuitToken : CancellationTokenOnEnd;
            var taskA = _transitionCtrl.ClearAsync(ct);
            var taskB = _volumeCore.FadeAsync(
                new MornSoundVolumeFadeInfo
                {
                    SoundVolumeType = MornDirectorGlobal.I.VolumeFadeType,
                    IsFadeIn = true,
                    Duration = MornDirectorGlobal.I.VolumeFadeInDuration,
                });
            await UniTask.WhenAll(taskA, taskB);
            Transition(_nextState);
        }
    }
}