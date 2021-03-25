using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace CubeClash.Scripts.Assembly.Util
{
    [RequireComponent(typeof(Animator))]
    public class PlayableAnimator : MonoBehaviour
    {
        [SerializeField] private List<AnimationClip> animationClips;
        public bool playOnAwake;

        private Animator animator;
        private PlayableGraph playableGraph;
        public AnimationClip CurrentAnimationClip { get; private set; }

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();

            if (playOnAwake && animationClips.Count > 0)
            {
                Play(animationClips[0]);
            }
        }

        public void Play(string clip)
        {
            Play(GetAnimationClip(clip));
        }

        public void Play(AnimationClip clip)
        {
            if (!playableGraph.Equals(default(PlayableGraph)) && playableGraph.IsPlaying())
            {
                playableGraph.Stop();
            }

            CurrentAnimationClip = clip;

            playableGraph = PlayableGraph.Create();
            AnimationPlayableOutput animationOutput =
                AnimationPlayableOutput.Create(playableGraph, "Animation", animator);

            AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(playableGraph, CurrentAnimationClip);

            animationOutput.SetSourcePlayable(clipPlayable);

            playableGraph.Play();
        }

        private AnimationClip GetAnimationClip(string clipName)
        {
            return animationClips.Find(x => x.name.Equals(clipName));
        }
    }
}