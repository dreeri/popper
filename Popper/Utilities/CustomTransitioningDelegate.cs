using System;
using CoreGraphics;
using UIKit;

namespace Popper.Utilities
{
    public class CustomTransitioningDelegate : UIViewControllerTransitioningDelegate
    {
        readonly CGRect ViewFrame;

        public CustomTransitioningDelegate(CGRect viewFrame)
        {
            ViewFrame = viewFrame;
        }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source)
        {
            var customAnimationController = new PopAnimationController();
            customAnimationController.OriginFrame = ViewFrame;
            return customAnimationController;
        }
    }
}
