using System;
using CoreGraphics;
using UIKit;

namespace Popper.Utilities
{
    public class PopAnimationController : UIViewControllerAnimatedTransitioning
    {
        public CGRect OriginFrame = CGRect.Empty;

        const double Duration = 2;

        public PopAnimationController()
        {
        }

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var fromViewController = transitionContext.GetViewControllerForKey(UITransitionContext.FromViewControllerKey);
            var containerView = transitionContext.ContainerView;
            var toViewController = transitionContext.GetViewControllerForKey(UITransitionContext.ToViewControllerKey);

            var finalFrame = transitionContext.GetFinalFrameForViewController(toViewController);

            containerView.AddSubview(toViewController.View);
            toViewController.View.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width, finalFrame.Y, finalFrame.Width, finalFrame.Height);

            UIView.Animate(Duration, () =>
            {
                toViewController.View.Frame = new CGRect(finalFrame.X, finalFrame.Y, finalFrame.Width, finalFrame.Height);
            }, () =>
            {
                transitionContext.CompleteTransition(!transitionContext.TransitionWasCancelled);
            });
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return Duration;
        }
    }
}
