using System;
using CoreGraphics;
using UIKit;

namespace Popper.Utilities
{
    public class PopTransitioningDelegate : UIViewControllerTransitioningDelegate
    {
        float DynamicsMass;

        float DynamicsTension;

        float DynamicsFriction;

        public PopTransitioningDelegate(float dynamicsMass, float dynamicsTension, float dynamicsFriction)
        {
            DynamicsMass = dynamicsMass;
            DynamicsTension = dynamicsTension;
            DynamicsFriction = dynamicsFriction;
        }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForPresentedController(UIViewController presented, UIViewController presenting, UIViewController source)
        {
            var customAnimationController = new PopAnimationController(DynamicsMass, DynamicsTension, DynamicsFriction);
            return customAnimationController;
        }
    }
}
