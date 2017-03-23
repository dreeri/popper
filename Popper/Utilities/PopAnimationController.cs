using System;
using CoreGraphics;
using Facebook.Pop;
using Foundation;
using UIKit;

namespace Popper.Utilities
{
    public class PopAnimationController : UIViewControllerAnimatedTransitioning
    {
        float DynamicsMass;

        float DynamicsTension;

        float DynamicsFriction;

        const double UIViewAnimationDuration = 0.400;

        public PopAnimationController(float dynamicsMass, float dynamicsTension, float dynamicsFriction)
        {
            DynamicsMass = dynamicsMass;
            DynamicsTension = dynamicsTension;
            DynamicsFriction = dynamicsFriction;
        }

        void DoPopSringAnimation(UIView toView, CGRect finalFrame, IUIViewControllerContextTransitioning transitionContext)
        {
            var animation = POPSpringAnimation.AnimationWithPropertyNamed(POPAnimation.LayerPosition);
            var location = new CGPoint(finalFrame.X + finalFrame.Width / 2, finalFrame.Y + finalFrame.Height / 2);
            animation.ToValue = NSValue.FromCGPoint(location);
            animation.DynamicsMass = DynamicsMass;
            animation.DynamicsTension = DynamicsTension;
            animation.DynamicsFriction = DynamicsFriction;
            animation.CompletionAction = (arg1, arg2) =>
                {
                    transitionContext.CompleteTransition(!transitionContext.TransitionWasCancelled);
                };
            toView.Layer.AddAnimation(animation, "location");
        }

        void DoUIViewAnimation(UIView toView, CGRect finalFrame, IUIViewControllerContextTransitioning transitionContext)
        {
            UIView.Animate(UIViewAnimationDuration, () =>
            {
                toView.Frame = finalFrame;
            }, () =>
            {
                transitionContext.CompleteTransition(!transitionContext.TransitionWasCancelled);
            });
        }

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var containerView = transitionContext.ContainerView;
            var toViewController = transitionContext.GetViewControllerForKey(UITransitionContext.ToViewControllerKey);
            var finalFrame = transitionContext.GetFinalFrameForViewController(toViewController);

            containerView.AddSubview(toViewController.View);
            toViewController.View.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width, finalFrame.Y, finalFrame.Width * 2, finalFrame.Height);

            DoPopSringAnimation(toViewController.View, finalFrame, transitionContext);
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return UIViewAnimationDuration;
        }
    }
}
