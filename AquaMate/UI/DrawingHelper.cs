using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace AquaMate.UI
{
    /// <summary>Allows suspending and resuming redrawing a Windows Forms window via the <b>WM_SETREDRAW</b> 
    /// Windows message.</summary>
    /// <remarks>Usage: The window for which drawing will be suspended and resumed needs to instantiate this type, 
    /// passing a reference to itself to the constructor, then call either of the public methods. For each call to 
    /// <b>SuspendDrawing</b>, a corresponding <b>ResumeDrawing</b> call must be made. Calls may be nested, but
    /// should not be made from any other than the GUI thread. (This code tries to work around such an error, but 
    /// is not guaranteed to succeed.)</remarks>
    public class DrawingHelper
    {
        private const int WM_SETREDRAW = 11;

        private readonly IWin32Window fOwner;
        private int fSuspendCounter;
        private readonly SynchronizationContext fSyncContext;


        public DrawingHelper(IWin32Window owner)
        {
            fOwner = owner;
            fSyncContext = SynchronizationContext.Current;
        }

        /// <summary>This overload allows you to specify whether the optimal flags for a container 
        /// or child control should be used. To specify custom flags, use the overload that accepts 
        /// a <see cref="RedrawWindowFlags"/> parameter.</summary>
        /// <param name="isContainer">When <b>true</b>, the optimal flags for redrawing a container 
        /// control are used; otherwise the optimal flags for a child control are used.</param>
        public void ResumeDrawing(bool isContainer = false)
        {
            RedrawWindowFlags flags;
            if (isContainer) {
                flags = RedrawWindowFlags.Erase | RedrawWindowFlags.Frame | RedrawWindowFlags.Invalidate | RedrawWindowFlags.AllChildren;
            } else {
                flags = RedrawWindowFlags.NoErase | RedrawWindowFlags.Invalidate | RedrawWindowFlags.InternalPaint;
            }

            Interlocked.Decrement(ref fSuspendCounter);

            if (fSuspendCounter == 0) {
                Action resume = new Action(() => {
                    NativeMethods.SendMessage(fOwner.Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
                    NativeMethods.RedrawWindow(fOwner.Handle, IntPtr.Zero, IntPtr.Zero, flags);
                });
                try {
                    resume();
                } catch (InvalidOperationException) {
                    fSyncContext.Post(s => ((Action)s)(), resume);
                }
            }
        }

        public void SuspendDrawing()
        {
            try {
                if (fSuspendCounter == 0) {
                    Action suspend = new Action(() => NativeMethods.SendMessage(fOwner.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero));
                    try {
                        suspend();
                    } catch (InvalidOperationException) {
                        fSyncContext.Post(s => ((Action)s)(), suspend);
                    }
                }
            } finally {
                Interlocked.Increment(ref fSuspendCounter);
            }
        }


        [SuppressUnmanagedCodeSecurity]
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, IntPtr wParam, IntPtr lParam);
        }


        [Flags]
        internal enum RedrawWindowFlags : uint
        {
            ///<summary>Invalidates lprcUpdate or hrgnUpdate (only one may be non-NULL). 
            ///If both are NULL, the entire window is invalidated.</summary>
            Invalidate = 0x1,

            ///<summary>Causes a WM_PAINT message to be posted to the window regardless of 
            ///whether any portion of the window is invalid.</summary>
            InternalPaint = 0x2,

            ///<summary>Causes the window to receive a WM_ERASEBKGND message when the window 
            ///is repainted. The <b>Invalidate</b> flag must also be specified; otherwise, 
            ///<b>Erase</b> has no effect.</summary>
            Erase = 0x4,

            ///<summary>Validates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both 
            ///are NULL, the entire window is validated. This flag does not affect internal 
            ///WM_PAINT messages.</summary>
            Validate = 0x8,

            ///<summary>Suppresses any pending internal WM_PAINT messages. This flag does not 
            ///affect WM_PAINT messages resulting from a non-NULL update area.</summary>
            NoInternalPaint = 0x10,

            ///<summary>Suppresses any pending WM_ERASEBKGND messages.</summary>
            NoErase = 0x20,

            ///<summary>Excludes child windows, if any, from the repainting operation.</summary>
            NoChildren = 0x40,

            ///<summary>Includes child windows, if any, in the repainting operation.</summary>
            AllChildren = 0x80,

            ///<summary>Causes the affected windows (as specified by the <b>AllChildren</b> and <b>NoChildren</b> flags) to 
            ///receive WM_NCPAINT, WM_ERASEBKGND, and WM_PAINT messages, if necessary, before the function returns.</summary>
            UpdateNow = 0x100,

            ///<summary>Causes the affected windows (as specified by the <b>AllChildren</b> and <b>NoChildren</b> flags) 
            ///to receive WM_NCPAINT and WM_ERASEBKGND messages, if necessary, before the function returns. 
            ///WM_PAINT messages are received at the ordinary time.</summary>
            EraseNow = 0x200,

            ///<summary>Causes any part of the nonclient area of the window that intersects the update region 
            ///to receive a WM_NCPAINT message. The <b>Invalidate</b> flag must also be specified; otherwise, 
            ///<b>Frame</b> has no effect. The WM_NCPAINT message is typically not sent during the execution of 
            ///RedrawWindow unless either <b>UpdateNow</b> or <b>EraseNow</b> is specified.</summary>
            Frame = 0x400,

            ///<summary>Suppresses any pending WM_NCPAINT messages. This flag must be used with <b>Validate</b> and 
            ///is typically used with <b>NoChildren</b>. <b>NoFrame</b> should be used with care, as it could cause parts 
            ///of a window to be painted improperly.</summary>
            NoFrame = 0x800
        }
    }
}
